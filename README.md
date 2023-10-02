# YTGrab
Download and extract audio from your favorite YouTube videos 🚀!



## ▶️ Setup

1. Clone repository and open directory:
   ```sh
   git clone https://github.com/YWKBM/YTGrab.git
2. Configure the `appsettings.json` by using your bot-token:
   
   ```sh
     "BotConfiguration": {
    "botToken": "{your_bot_token}"
    },
3. Configure ngrok.yml by using your authtoken:
```sh
version: "2"
authtoken: {your_authtoken}
tunnels:
  YTGrab:
    addr: 80
    proto: http
```
4.Build and run the project.
    ```sh
    docker-compose up -d
    ```
6. Sign webhook
   ```sh
   https://api.telegram.org/bot{bot_token}/setWebhook?url={your_ngrok_tunnel_url}
   ```
