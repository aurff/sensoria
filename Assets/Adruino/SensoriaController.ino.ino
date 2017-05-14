const int fsrAnalogPin = 0;
int fsrReadingValue;
 
void setup(void) 
{
  // sends debugging information to the serial monitor
  Serial.begin(9600);
}
 
void loop(void) 
{
  fsrReadingValue = analogRead(fsrAnalogPin);
  // TODO check for threshold value (pillow)
  if (fsrReadingValue != 0)
  {
    Serial.write(1);
    Serial.flush();
    delay(20);
  }
  if (fsrReadingValue == 0)
  {
    Serial.write(2);
    Serial.flush();
    delay(20);
  }

}

