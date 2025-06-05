using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;

namespace CSGenio.core.ai
{
    /// <summary>
    /// Abstract class extending AiAgent to provide a structured model-based AI Agent.
    /// This class is meant to handle data loading and execution logic for AI agents that work with models.
    /// </summary>
    public abstract class ModelAiAgent : AiAgent
    {
        /// <summary>
        /// Constructor initializing the ModelAiAgent with an AI chatbot service.
        /// </summary>
        /// <param name="service">Instance of IChatbotService for AI interactions.</param>
        protected ModelAiAgent(IChatbotService service) : base(service)
        {
        }

        /// <summary>
        /// Executes the AI agent's main logic using the provided database area, persistent support, and user context.
        /// This method must be implemented by derived classes.
        /// </summary>
        /// <param name="area">The database area that the agent operates on.</param>
        /// <param name="sp">Persistent support object for data transactions.</param>
        /// <param name="user">User executing the operation.</param>
        public abstract void Execute(DbArea area, PersistentSupport sp, User user);

        /// <summary>
        /// Persists the changes in the base area record
        /// </summary>
        public abstract void PersistRecord(PersistentSupport sp);

        /// <summary>
        /// Loads records from the database that are relevant to the agent's operation.
        /// This method must be implemented by derived classes to retrieve necessary data.
        /// </summary>
        /// <param name="area">The database area containing the records.</param>
        /// <param name="sp">Persistent support for handling database interactions.</param>
        /// <param name="user">User requesting the data.</param>
        public abstract void LoadRecords(DbArea area, PersistentSupport sp, User user);
    }
}