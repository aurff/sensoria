const int fsrAnalogPin = 1;
const int buttonPin = 7;
const int buttonTwoPin = 8;

const int buttonPressed = 1;
const int buttonNotPressed = 2;
const int buttonTwoPressed = 3;
const int buttonTwoNotPressed = 4;
const int fsrPinPressed = 5;
const int fsrPinNotPressed = 6;

int buttonState = 0;
int buttonTwoState = 0;
int fsrReadingValue;

void setup() {
  
  Serial.begin(9600);
  pinMode(buttonPin, INPUT);
  pinMode(buttonTwoPin, INPUT);

}

void loop() {
  
  buttonState = digitalRead(buttonPin);
  buttonTwoState = digitalRead(buttonTwoPin);
  fsrReadingValue = analogRead(fsrAnalogPin);
  
  if (buttonState == HIGH) 
  {
    // Serial.println("Button pressed");
    Serial.write(buttonPressed);
    Serial.flush();
    delay(20);
  }
  else if (buttonState == LOW)
  {
    // Serial.println("Button not pressed");
    Serial.write(buttonNotPressed);
    Serial.flush();
    delay(20);
  }

  if (buttonTwoState == HIGH) 
  {
    // Serial.println("Button 2 pressed");
    Serial.write(buttonTwoPressed);
    Serial.flush();
    delay(20);
  }
  else if (buttonTwoState == LOW)
  {
    // Serial.println("Button 2 not pressed");
    Serial.write(buttonTwoNotPressed);
    Serial.flush();
    delay(20);
  }
  // TODO check for threshold value (pillow)
  if (fsrReadingValue != 0)
  {
    // Serial.println("Pressure");
    Serial.write(fsrPinPressed);
    Serial.flush();
    delay(20);
  }
  
  if (fsrReadingValue == 0)
  {
    // Serial.println("No Pressure");
    Serial.write(fsrPinNotPressed);
    Serial.flush();
    delay(20);
  }
}
