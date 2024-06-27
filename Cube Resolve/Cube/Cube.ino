#include <Servo.h>

Servo servo1;
Servo servo2;
Servo servo3;
Servo servo4;
Servo servo5;
Servo servo6;
Servo servo7;
Servo servo8;

void setup(){
  Serial.begin(9600);
}
 
void loop() {
  if (Serial.available()) {
    char command = Serial.read();
    if (command == '1') {
      AcomodarCubo();
    }
    if (command == '2') {
      SacarCubo();
    }
    if (command == '3') {
      Pruebas();
    }


    if (command == 'W') {
      Giro1();
    }

    if (command == 'X') {
      Giro2();
    }

    if (command == 'Y') {
      Giro3();
    }

    if (command == 'Z') {
      Giro4();
    }


    if (command == 'A') {
      movR();
    }
    if (command == 'B') {
      movR2();
    }
    if (command == 'C') {
      movRP();
    }

    if (command == 'D') {
      movL();
    }
    if (command == 'E') {
      movL2();
    }
    if (command == 'F') {
      movLP();
    }

    if (command == 'G') {
      movF();
    }
    if (command == 'H') {
      movF2();
    }
    if (command == 'I') {
      movFP();
    }

    if (command == 'J') {
      movB();
    }
    if (command == 'K') {
      movB2();
    }
    if (command == 'L') {
      movBP();
    }

    if (command == 'M') {
      movU();
    }
    if (command == 'N') {
      movU2();
    }
    if (command == 'O') {
      movUP();
    }

    if (command == 'P') {
      movD();
    }
    if (command == 'Q') {
      movD2();
    }
    if (command == 'R') {
      movDP();
    }
  }
}


void Giro1() {
  
  servo1.attach(8); 
  
  servo1.write(0);
  delay(1000);

  servo2.attach(9);
  
  servo2.write(118);
  delay(1000);

  servo1.write(90);
  delay(1000);
  
  servo3.attach(2); 
  
  servo3.write(90);
  servo7.attach(6); 
  
  servo7.write(90);
  delay(500);

  servo6.attach(5);
  
  servo6.write(103);
  servo2.write(15);
  delay(500);

  servo3.write(0);
  servo7.write(0);
  delay(500);

  servo5.attach(4); 
  
  servo5.write(0);
  delay(1000);
  
  servo6.write(0);
  delay(1000);
  
  servo5.write(90);
  delay(1000);
  
  
  servo1.detach();
  servo2.detach();
  servo3.detach();
  servo5.detach();
  servo6.detach();
  servo7.detach();
}

void Giro2() {

  servo3.attach(2); 
  
  servo3.write(90);
  delay(1000);

  servo4.attach(3);
  
  servo4.write(103);
  delay(1000);

  servo3.write(0);
  delay(1000);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(500);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(500);

  servo1.write(90);
  servo5.write(90);
  delay(500);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(1000);
  
  servo8.write(0);
  delay(1000);
  
  servo7.write(0);
  delay(1000);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

void Giro3() {

  servo3.attach(2); 
  
  servo3.write(90);
  delay(1000);

  servo4.attach(3);
  
  servo4.write(103);
  delay(1000);

  servo3.write(0);
  delay(1000);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(500);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(500);

  servo1.write(90);
  servo5.write(90);
  delay(500);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(1000);
  
  servo8.write(0);
  delay(1000);
  
  servo7.write(0);
  delay(1000);
  
  servo3.attach(2); 
  
  servo3.write(90);
  delay(1000);

  servo4.attach(3);
  
  servo4.write(103);
  delay(1000);

  servo3.write(0);
  delay(1000);
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(500);
  
  servo8.write(103);
  servo4.write(0);
  delay(500);

  servo1.write(90);
  servo5.write(90);
  delay(500);
  
  servo7.write(90);
  delay(1000);
  
  servo8.write(0);
  delay(1000);
  
  servo7.write(0);
  delay(1000);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

void Giro4() {

  servo3.attach(2); 
  
  servo3.write(90);
  delay(1000);

  servo4.attach(3);
  
  servo4.write(103);
  delay(1000);

  servo3.write(0);
  delay(1000);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(500);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(500);

  servo1.write(90);
  servo5.write(90);
  delay(500);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(1000);
  
  servo8.write(0);
  delay(1000);
  
  servo7.write(0);
  delay(1000);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


  servo1.attach(8); 
  
  servo1.write(0);
  delay(1000);

  servo2.attach(9);
  
  servo2.write(118);
  delay(1000);

  servo1.write(90);
  delay(1000);
  
  servo3.attach(2); 
  
  servo3.write(90);
  servo7.attach(6); 
  
  servo7.write(90);
  delay(500);

  servo6.attach(5);
  
  servo6.write(103);
  servo2.write(5);
  delay(500);

  servo3.write(0);
  servo7.write(0);
  delay(500);

  servo5.attach(4); 
  
  servo5.write(0);
  delay(1000);
  
  servo6.write(0);
  delay(1000);
  
  servo5.write(90);
  delay(1000);
  
  
  servo1.detach();
  servo2.detach();
  servo3.detach();
  servo5.detach();
  servo6.detach();
  servo7.detach();
}


void AcomodarCubo() {
servo1.attach(8);
servo1.write(90);
delay(3000);
servo1.detach();

servo2.attach(9);
servo2.write(15);
delay(500);
servo2.detach();

servo3.attach(2);
servo3.write(0);
delay(3000);
servo3.detach();

servo4.attach(3);
servo4.write(0);
delay(500);
servo4.detach();

servo5.attach(4);
servo5.write(90);
delay(3000);
servo5.detach();

servo6.attach(5);
servo6.write(0);
delay(500);
servo6.detach();

servo7.attach(6);
servo7.write(0);
delay(3000);
servo7.detach();

servo8.attach(7);
servo8.write(0);
delay(500);
servo8.detach();
}

void SacarCubo() {

servo1.attach(8);
servo1.write(0);
delay(25);
servo1.detach();

servo2.attach(9);
servo2.write(15);
delay(25);
servo2.detach();

servo3.attach(2);
servo3.write(90);
delay(25);
servo3.detach();

servo4.attach(3);
servo4.write(0);
delay(25);
servo4.detach();

servo5.attach(4);
servo5.write(0);
delay(25);
servo5.detach();

servo6.attach(5);
servo6.write(0);
delay(25);
servo6.detach();

servo7.attach(6);
servo7.write(90);
delay(30);
servo7.detach();

servo8.attach(7);
servo8.write(0);
delay(30);
servo8.detach();
}

void Pruebas() {

for(int i = 1; i <= 4; i++)
 {
  servo1.attach(8); 
  
  servo1.write(90);
  delay(500);
  servo1.write(55);
  delay(500);

  servo2.attach(9);
  
  servo2.write(118);
  delay(500);

  servo1.write(0);
  delay(500);
  
  servo2.write(15);
  delay(500);
  
  servo1.write(90);
  delay(500);
  
  servo1.detach();
  servo2.detach();
 }

for(int i = 1; i <= 4; i++)
 {
  servo1.attach(8);

  servo1.write(0);
  delay(500);

  servo2.attach(9);

  servo2.write(118);
  delay(500);

  servo1.write(90);
  delay(500); 

  servo1.write(55);
  delay(500);

  servo2.write(10);
  delay(500);
  
  servo2.write(15);
  delay(30);
  servo1.write(90);
  delay(500);

  servo1.detach();
  servo2.detach();
 }

 for(int i = 1; i <= 4; i++)
 {
  servo3.attach(2); 
  
  servo3.write(0);
  delay(500);
  servo3.write(30);
  delay(500);

  servo4.attach(3);
  
  servo4.write(103);
  delay(500);

  servo3.write(90);
  delay(500);
  
  servo4.write(0);
  delay(500);
  
  servo3.write(0);
  delay(500);
  
  servo3.detach();
  servo4.detach();
 }

 for(int i = 1; i <= 4; i++)
 {
  servo3.attach(2);

  servo3.write(90);
  delay(500);

  servo4.attach(3);

  servo4.write(103);
  delay(500);

  servo3.write(0);
  delay(500); 

  servo3.write(30);
  delay(500);

  servo4.write(0);
  delay(500);
  
  servo3.write(0);
  delay(500);

  servo1.detach();
  servo2.detach();
 }
  
 for(int i = 1; i <= 4; i++)
 {
  servo5.attach(4); 
  
  servo5.write(90);
  delay(500);
  servo5.write(60);
  delay(500);

  servo6.attach(5);
  
  servo6.write(103);
  delay(500);

  servo5.write(0);
  delay(500);
  
  servo6.write(0);
  delay(500);
  
  servo5.write(90);
  delay(500);
  
  servo5.detach();
  servo6.detach();
 }

 for(int i = 1; i <= 4; i++)
 {
  servo5.attach(4);

  servo5.write(0);
  delay(500);

  servo6.attach(5);

  servo6.write(103);
  delay(500);

  servo5.write(90);
  delay(500); 

  servo5.write(60);
  delay(500);

  servo6.write(0);
  delay(500);
  
  servo5.write(90);
  delay(500);

  servo1.detach();
  servo2.detach();
 }

 for(int i = 1; i <= 4; i++)
 {
  servo7.attach(6); 
  
  servo7.write(0);
  delay(500);
  servo7.write(23);
  delay(500);

  servo8.attach(7);
  
  servo8.write(109);
  delay(500);

  servo7.write(90);
  delay(500);
  
  servo8.write(0);
  delay(500);
  
  servo7.write(0);
  delay(500);
  
  servo7.detach();
  servo8.detach();
 }

 for(int i = 1; i <= 4; i++)
 {
  servo7.attach(6);

  servo7.write(90);
  delay(500);

  servo8.attach(7);

  servo8.write(103);
  delay(500);

  servo7.write(0);
  delay(500); 

  servo7.write(23);
  delay(500);

  servo8.write(0);
  delay(500);
  
  servo7.write(0);
  delay(500);

  servo1.detach();
  servo2.detach();
 }
}


//R
void movR() {
  servo3.attach(2); 

  servo3.write(30);
  delay(400);

  servo4.attach(3);

  servo4.write(103);
  delay(400);

  servo3.write(90);
  delay(400);

  servo4.write(0);
  delay(400);

  servo3.write(0);
  delay(400);

  servo3.detach();
  servo4.detach();
}

void movR2() {
 for(int i = 1; i<= 2; i++)
 {
  servo3.attach(2); 

  servo3.write(30);
  delay(400);

  servo4.attach(3);

  servo4.write(103);
  delay(400);

  servo3.write(90);
  delay(400);

  servo4.write(0);
  delay(400);

  servo3.write(0);
  delay(400);

  servo3.detach();
  servo4.detach();
 }
}

void movRP() {
  servo3.attach(2); 

  servo3.write(90);
  delay(400);

  servo4.attach(3);

  servo4.write(98);
  delay(400);

  servo3.write(0);
  delay(400);

  servo3.write(30);
  delay(400);

  servo4.write(0);
  delay(500);

  servo3.write(0);
  delay(400);

  servo3.detach();
  servo4.detach();
}

//L
void movL() {
  servo7.attach(6); 

  servo7.write(23);
  delay(400);

  servo8.attach(7);

  servo8.write(103);
  delay(400);

  servo7.write(90);
  delay(400);

  servo8.write(0);
  delay(400);

  servo7.write(0);
  delay(400);

  servo7.detach();
  servo8.detach();
}

void movL2() {
 for(int i = 1; i<= 2; i++)
 {
  servo7.attach(6); 

  servo7.write(23);
  delay(400);

  servo8.attach(7);

  servo8.write(103);
  delay(400);

  servo7.write(90);
  delay(400);

  servo8.write(0);
  delay(400);

  servo7.write(0);
  delay(400);

  servo7.detach();
  servo8.detach();
 }
}

void movLP() {
  servo7.attach(6); 

  servo7.write(90);
  delay(400);

  servo8.attach(7);

  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(400);

  servo7.write(23);
  delay(400);

  servo8.write(0);
  delay(500);

  servo7.write(0);
  delay(400);

  servo7.detach();
  servo8.detach();
}

//F
void movF() {
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);

  servo4.attach(3);
  
  servo4.write(96);
  delay(400);

  servo3.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);
  
  servo8.write(0);
  delay(400);
  
  servo7.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


  servo1.attach(8);

  servo1.write(55);
  delay(400); 
  
  servo2.attach(9);

  servo2.write(118);
  delay(400);

  servo1.write(0);
  delay(400);

  servo2.write(15);
  delay(400);

  servo1.write(90);
  delay(400);

  servo1.detach();
  servo2.detach();


  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);

  servo8.attach(7);
  
  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo4.attach(3);
  
  servo4.write(98);
  servo8.write(5);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);
  
  servo8.write(0);
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);
  
  servo4.write(0);
  delay(400);
  
  servo3.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

void movF2() {
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);

  servo4.attach(3);
  
  servo4.write(96);
  delay(400);

  servo3.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);
  
  servo8.write(0);
  delay(400);
  
  servo7.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


for(int i = 1; i<= 2; i++)
 {
  servo1.attach(8);

  servo1.write(55);
  delay(400); 
  
  servo2.attach(9);

  servo2.write(118);
  delay(400);

  servo1.write(0);
  delay(400);

  servo2.write(15);
  delay(400);

  servo1.write(90);
  delay(400);

  servo1.detach();
  servo2.detach();
  }


  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);

  servo8.attach(7);
  
  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(500);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo4.attach(3);
  
  servo4.write(98);
  servo8.write(5);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);
  
  servo8.write(0);
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);
  
  servo4.write(0);
  delay(400);
  
  servo3.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

void movFP() {
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);

  servo4.attach(3);
  
  servo4.write(96);
  delay(400);

  servo3.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);
  
  servo8.write(0);
  delay(400);
  
  servo7.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


  servo1.attach(8);

  servo1.write(0);
  delay(400);

  servo2.attach(9);

  servo2.write(118);
  delay(400);

  servo1.write(90);
  delay(400); 

  servo1.write(55);
  delay(400);

  servo2.write(10);
  delay(500);
  
  servo2.write(15);
  delay(30);
  servo1.write(90);
  delay(400);

  servo1.detach();
  servo2.detach();


  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);

  servo8.attach(7);
  
  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo4.attach(3);
  
  servo4.write(98);
  servo8.write(5);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);
  
  servo8.write(0);
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);
  
  servo4.write(0);
  delay(400);
  
  servo3.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

//B
void movB() {
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);

  servo4.attach(3);
  
  servo4.write(96);
  delay(400);

  servo3.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);
  
  servo8.write(0);
  delay(400);
  
  servo7.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


  servo5.attach(4);

  servo5.write(60);
  delay(400); 
  
  servo6.attach(5);

  servo6.write(103);
  delay(400);

  servo5.write(0);
  delay(400);

  servo6.write(0);
  delay(400);

  servo5.write(90);
  delay(400);

  servo5.detach();
  servo6.detach();


  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);

  servo8.attach(7);
  
  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo4.attach(3);
  
  servo4.write(98);
  servo8.write(5);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(500);
  
  servo8.write(0);
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);
  
  servo4.write(0);
  delay(400);
  
  servo3.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

void movB2() {
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);

  servo4.attach(3);
  
  servo4.write(96);
  delay(400);

  servo3.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);
  
  servo8.write(0);
  delay(400);
  
  servo7.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


for(int i = 1; i<= 2; i++)
 {
  servo5.attach(4);

  servo5.write(60);
  delay(400); 
  
  servo6.attach(5);

  servo6.write(103);
  delay(400);

  servo5.write(0);
  delay(400);

  servo6.write(0);
  delay(400);

  servo5.write(90);
  delay(400);

  servo5.detach();
  servo6.detach();
 }


  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);

  servo8.attach(7);
  
  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo4.attach(3);
  
  servo4.write(98);
  servo8.write(5);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);
  
  servo8.write(0);
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);
  
  servo4.write(0);
  delay(400);
  
  servo3.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

void movBP() {
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);

  servo4.attach(3);
  
  servo4.write(96);
  delay(400);

  servo3.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo8.attach(7);
  
  servo8.write(103);
  servo4.write(0);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);

  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);
  
  servo8.write(0);
  delay(400);
  
  servo7.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();


  servo5.attach(4);

  servo5.write(0);
  delay(400);

  servo6.attach(5);

  servo6.write(103);
  delay(400);

  servo5.write(90);
  delay(400); 

  servo5.write(60);
  delay(400);

  servo6.write(0);
  delay(500);
  
  servo5.write(90);
  delay(400);

  servo5.detach();
  servo6.detach();


  servo7.attach(6); 
  
  servo7.write(90);
  delay(400);

  servo8.attach(7);
  
  servo8.write(100);
  delay(400);

  servo7.write(0);
  delay(400);
  
  servo1.attach(8); 
  
  servo1.write(0);
  servo5.attach(4); 
  
  servo5.write(0);
  delay(400);

  servo4.attach(3);
  
  servo4.write(98);
  servo8.write(5);
  delay(400);

  servo1.write(90);
  servo5.write(90);
  delay(400);
  
  servo8.write(0);
  servo3.attach(2); 
  
  servo3.write(90);
  delay(400);
  
  servo4.write(0);
  delay(400);
  
  servo3.write(0);
  delay(400);
  

  servo1.detach();
  servo3.detach();
  servo4.detach();
  servo5.detach();
  servo7.detach();
  servo8.detach();
}

//U
void movU() {
  servo5.attach(4);

  servo5.write(60);
  delay(400); 
  
  servo6.attach(5);

  servo6.write(103);
  delay(400);

  servo5.write(0);
  delay(400);

  servo6.write(0);
  delay(400);

  servo5.write(90);
  delay(400);

  servo5.detach();
  servo6.detach();
}

void movU2() {
 for(int i = 1; i<= 2; i++)
 {
  servo5.attach(4);

  servo5.write(60);
  delay(400); 
  
  servo6.attach(5);

  servo6.write(103);
  delay(400);

  servo5.write(0);
  delay(400);

  servo6.write(0);
  delay(400);

  servo5.write(90);
  delay(400);

  servo5.detach();
  servo6.detach();
 }
}

void movUP() {
  servo5.attach(4);

  servo5.write(0);
  delay(400);

  servo6.attach(5);

  servo6.write(103);
  delay(400);

  servo5.write(90);
  delay(400); 

  servo5.write(60);
  delay(400);

  servo6.write(0);
  delay(500);
  
  servo5.write(90);
  delay(400);

  servo5.detach();
  servo6.detach();
}

//D
void movD() {
  servo1.attach(8);

  servo1.write(55);
  delay(400); 
  
  servo2.attach(9);

  servo2.write(118);
  delay(400);

  servo1.write(0);
  delay(400);

  servo2.write(15);
  delay(400);

  servo1.write(90);
  delay(400);

  servo1.detach();
  servo2.detach();
}

void movD2() {
 for(int i = 1; i<= 2; i++)
 {
  servo1.attach(8);

  servo1.write(55);
  delay(400); 
  
  servo2.attach(9);

  servo2.write(118);
  delay(400);

  servo1.write(0);
  delay(400);

  servo2.write(15);
  delay(400);

  servo1.write(90);
  delay(400);

  servo1.detach();
  servo2.detach();
  }
}

void movDP() {
  servo1.attach(8);

  servo1.write(0);
  delay(400);

  servo2.attach(9);

  servo2.write(118);
  delay(400);

  servo1.write(90);
  delay(400); 

  servo1.write(55);
  delay(400);

  servo2.write(10);
  delay(500);
  
  servo2.write(15);
  delay(30);
  servo1.write(90);
  delay(400);

  servo1.detach();
  servo2.detach();
}
