#include <Wire.h>  // Include Wire if you're using I2C
#include <SPI.h>  // Include SPI if you're using SPI
#include <ER_MicroOLED.h>  // Include the SFE_MicroOLED library

//////////////////////////
// MicroOLED Definition //
//////////////////////////
#define PIN_RESET 255  // Connect RST to pin 9 (req. for SPI and I2C)
//#define PIN_DC    8  // Connect DC to pin 8 (required for SPI)
//#define PIN_CS    10 // Connect CS to pin 10 (required for SPI)
#define DC_JUMPER 0
// Also connect pin 13 to SCK and pin 11 to MOSI

//////////////////////////////////
// MicroOLED Object Declaration //
//////////////////////////////////
// Declare a MicroOLED object. The parameters include:
// 1 - Reset pin: Any digital pin
// 2 - D/C pin: Any digital pin (SPI mode only)
// 3 - CS pin: Any digital pin (SPI mode only, 10 recommended)
//MicroOLED oled(PIN_RESET, PIN_DC, PIN_CS);
MicroOLED oled(PIN_RESET, DC_JUMPER); // Example I2C declaration

// I2C is great, but will result in a much slower update rate. The
// slower framerate may be a worthwhile tradeoff, if you need more
// pins, though.
void setup()
{
  // These three lines of code are all you need to initialize the
  // OLED and print the splash screen.
  
  // Before you can start using the OLED, call begin() to init
  // all of the pins and configure the OLED.
  Serial.begin(9600);
  oled.begin();
  // clear(ALL) will clear out the OLED's graphic memory.
  // clear(PAGE) will clear the Arduino's display buffer.
  oled.clear(ALL);  // Clear the display's memory (gets rid of artifacts)
  // To actually draw anything on the display, you must call the
  // display() function. 
  oled.display();   
  delay(2000);
  oled.clear(PAGE);
  oled.clear(ALL);
  oled.setCursor(0,0);
  oled.setTextColor(WHITE);
  oled.setTextSize(0);
  oled.display();
  pinMode(A0,INPUT);
}

void loop()
{
  if(Serial.available()>0)
  {
    char readchar = char(Serial.read());
    if (readchar == '|')
    {
      oled.println();
    }
    else if (readchar == '?')
    {
      oled.clear(PAGE);
      oled.clear(ALL);
      oled.setCursor(0,0);
    }
    else if (readchar == '!')
    {
      oled.setTextSize(0);
    }
    else if (readchar == '@')
    {
      oled.setTextSize(1);
    }
    else if (readchar == '#')
    {
      oled.setTextSize(2);
    }
    else if (readchar == '$')
    {
      oled.setTextSize(3);
    }
    else
    {
    oled.print(readchar);
    }
    oled.display();
  }
}
