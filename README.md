# YTGrab
Download and extract audio from your favorite YouTube videos 🚀!



▶️ YTGrab
===============

YTGrab is a telegram bot that allows you to download videos from YouTube and extract audio from them.

![image](https://github.com/YWKBM/YTGrab/assets/89938515/873c7834-2430-414d-b050-70df8b316d3e) ![image](https://github.com/YWKBM/YTGrab/assets/89938515/d5f7dff0-0cf9-4a8e-b8cf-f8f39dd59c43)



## 🚀 Setup

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
4.Build and run the project:

    docker-compose up -d

    
5. Sign webhook
   ```sh
   https://api.telegram.org/bot{bot_token}/setWebhook?url={your_ngrok_tunnel_url}
   ```
