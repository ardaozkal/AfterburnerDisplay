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

Pretty much everything. I just need to change some minor stuff.
