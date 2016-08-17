# AfterburnerDisplay
Display Afterburner stats on ESP8266

![How it looks](https://pbs.twimg.com/media/CqCW3fhXEAAy9nj.jpg:large)

# How to install

Install https://github.com/EdwinRobotics/ER_Micro_OLED_Arduino_Library (Just download it as zip and [follow this](https://www.arduino.cc/en/Guide/Libraries#toc4))

Download arduino code and install on an ESP8266. Change ports as necessary, defaults are for Wemos D1 Mini and the OLED shield for it. Purchase links: [Wemos D1 Mini](http://www.aliexpress.com/store/product/D1-mini-Mini-NodeMcu-4M-bytes-Lua-WIFI-Internet-of-Things-development-board-based-ESP8266/1331105_32529101036.html), [Screen](http://www.aliexpress.com/store/product/OLED-Shield-for-WeMos-D1-mini-0-66-inch-64X48-IIC-I2C/1331105_32627787079.html).

[Install MSI Afterburner if you haven't already](https://gaming.msi.com/features/afterburner##downloads).

Run the Windows Code and answer the questions asked (Port name, baud rate and refresh rate).

If you want to edit it for using with other stuff, just use the [sample code here](http://playground.arduino.cc/Interfacing/Csharp). When you send a text, it'll display it. You can send !,@,# and $ to change text size, ? to clear screen and | to put a newline.

##What is ready?

Everything I planned for this project is done. Took 7 hours, but 4 hours of it was searching for a proper library (and losing loads of time in reddit slacking) because the official display library doesn't show texts.

##But why?

[Someone from a chatroom said that they use their 60usd keypad just to display afterburner info.](http://chat.stackexchange.com/transcript/35?m=31736992#31736992). I told them to give me a day and 5$, and I'd do the same. I ended up making the same for about $9.10 (when I first bought these parts they costed like $7, I blame Wemos) in 7 hours.

##Also, disclaimer: 

Users: I take no responsibility. All responsibility is yours.

MSI: I'm not affiliated with MSI in any way. This is a non-profit fan project, so don't takedown the repo please? I can rename it if you mail me from the mail on my github profile. 
