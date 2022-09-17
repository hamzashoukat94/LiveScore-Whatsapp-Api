# LiveScore-Whatsapp-Api
Initialize the WhatsappClientAPI client and provide the Access token.

	_whatsAppCloudAPIClient = new WhatsAppCloudAPIClient.Builder()
	.AccessToken(_configuration.GetValue<string>("WhatsApp:AccessToken"))
	.HttpClientConfig(config => config.NumberOfRetries(0))
	.Build();
	
Create an account with Sportsmonks account and generate an Access token to use the API.	

Download the C# SDK from the SportsMonks Cricket API Portal and add it as a project to your Solution.
Instantiate an instance of the sportmonksCricketApiClient by providing the Access token you retrieved in step 1.


	_sportmonksCricketAPIClient = new CricketAPIClient.Builder()
		.CustomQueryAuthenticationCredentials(_configuration.GetValue<string>("Sportsmonks:AccessToken")).Build();
		
		
We will use the All Inplay, Team By ID, Fixture with Run  endpoints of the Sportsmonks Cricket API to generate relevant responses for received messages. Call the custom GetLiveScore method to prepare the user-friendly response inside the POST webhook to generate messages.				


