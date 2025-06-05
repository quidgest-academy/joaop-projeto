

using CSGenio.core.di;
using CSGenio.framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSGenio.core.ai;

/// <summary>
/// Abstract class representing an AI Agent that interacts with a chatbot service.
/// </summary>
/// <typeparam name="OutData">The type of data expected as the response from the chatbot.</typeparam>
public abstract class AiAgent
{
    /// <summary>
    /// Protected field holding the chatbot service instance.
    /// </summary>
    protected readonly IChatbotService _service;

    /// <summary>
    /// Constructor for the AiAgent, ensuring a valid IChatbotService instance.
    /// </summary>
    /// <param name="service">An implementation of IChatbotService to communicate with the chatbot.</param>
    /// <exception cref="ArgumentNullException">Thrown if the service is null.</exception>
    public AiAgent(IChatbotService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    /// <summary>
    /// Gets the system prompt that defines the behavior of the AI agent.
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract string BuildSystemPrompt();

    /// <summary>
    /// Builds the user prompt sent to the AI agent
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract string BuildUserPrompt();

    /// <summary>
    /// Gets the JSON schema used to format the chatbot's response.
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract object JsonSchema { get; }

    public abstract string AGENT_ID { get; }

    /// <summary>
    /// Sends a prompt to the chatbot and retrieves a response asynchronously.
    /// </summary>
    /// <param name="prompt">The input message sent to the chatbot.</param>
    /// <param name="prompt">The user sending the request</param>
    /// <returns>A task representing the asynchronous operation, returning an instance of OutData.</returns>
    public async Task<OutData> GetResponseAsync<OutData>(User user)
    {

        try
        {
            var tags = new List<KeyValuePair<string, object>>() {
                new("agent", AGENT_ID)
            };
            GenioDI.MetricsOtlp.IncrementCounter("agent_call", 1, tags);
            using (GenioDI.MetricsOtlp.RecordTime("agent_load_time", tags, "ms", "Time to get response from agent"))
            {

                // Construct the request payload with necessary parameters
                var requestData = new
                {
                    jsonSchema = JsonSchema,
                    prompt = BuildUserPrompt(),
                    systemPrompt = BuildSystemPrompt(),
                    project = Configuration.Program // Static app identifier
                };
                Log.Info($"User ${user.Name} called {AGENT_ID}"); 
                // Call the chatbot service asynchronously and return the result
                return await _service.CallChatbotFunctionAsync<OutData>(requestData)
                    .ConfigureAwait(false);            
            }
        }
        catch (Exception ex)
        {
            Log.Error($"Error in agent {AGENT_ID}: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Sends a prompt to the chatbot and retrieves a response synchronously.
    /// </summary>
    /// <param name="prompt">The input message sent to the chatbot.</param>
    /// <param name="prompt">The user sending the request</param>
    /// <returns>An instance of OutData, parsed from the returned data</returns>
    public OutData GetResponse<OutData>(User user)
    {
        return GetResponseAsync<OutData>(user)
            .GetAwaiter()
            .GetResult();
    }
}

