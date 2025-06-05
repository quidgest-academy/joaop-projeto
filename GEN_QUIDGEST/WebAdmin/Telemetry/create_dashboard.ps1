# PowerShell Script: Post Full Server Status Dashboard
 
# Define variables (replace with your actual values)
$grafanaApiUrl = "http://localhost:3001"  # Replace with your Grafana URL
$adminUser = "quidgest"
$adminPassword = "zph2lab"

# Encode credentials for Basic Auth
$bytes = [System.Text.Encoding]::UTF8.GetBytes("$adminUser`:$adminPassword")
$base64Auth = [Convert]::ToBase64String($bytes)
 
# Set headers
$headers = @{
    "Content-Type"  = "application/json"
    "Authorization" = "Basic $base64Auth"
}


#-----------------------------------
# Create datasource
#-----------------------------------
$payload = Get-Content -Raw -Path "datasource_prometheus.json"

# Send POST request to Grafana API
Invoke-RestMethod -Uri "$grafanaApiUrl/api/datasources" `
                  -Method POST `
                  -Headers $headers `
                  -Body $payload `
                  -UseBasicParsing `
                  -SkipCertificateCheck  # only use this if you're connecting to a self-signed instance

$payload = Get-Content -Raw -Path "datasource_loki.json"

# Send POST request to Grafana API
Invoke-RestMethod -Uri "$grafanaApiUrl/api/datasources" `
                  -Method POST `
                  -Headers $headers `
                  -Body $payload `
                  -UseBasicParsing `
                  -SkipCertificateCheck  # only use this if you're connecting to a self-signed instance


#-----------------------------------
# Create dashboard
#-----------------------------------
$payload = Get-Content -Raw -Path "dashboard_metrics.json"

# Send POST request to Grafana API
Invoke-RestMethod -Uri "$grafanaApiUrl/api/dashboards/db" `
                  -Method POST `
                  -Headers $headers `
                  -Body $payload `
                  -UseBasicParsing `
                  -SkipCertificateCheck  # only use this if you're connecting to a self-signed instance
				  
$payload = Get-Content -Raw -Path "dashboard_logs.json"

# Send POST request to Grafana API
Invoke-RestMethod -Uri "$grafanaApiUrl/api/dashboards/db" `
                  -Method POST `
                  -Headers $headers `
                  -Body $payload `
                  -UseBasicParsing `
                  -SkipCertificateCheck  # only use this if you're connecting to a self-signed instance
