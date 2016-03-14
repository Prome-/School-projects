#include <iostream>
#include <string>
#include <ctime>
#include <fstream>

using namespace std;

struct monster							// structin sisällön määritys
{
	string name;
	int health, damage, criticalDMG, criticalChance;
};

//aliohjelmien esittelyt

void menu();						// ei palauta mitään eikä ota vastaan parametreja
struct monster archive(int);		// palauttaa structin ja ottaa vastaan integerin
int damageCount(int);				// palauttaa integerin ja ottaa vastaan integerin
int combat(int, char *);				// palauttaa integerin ja ottaa vastaan characterin ja integerin
int diceRoll(int);					// palauttaa integerin ja ottaa vastaan integerin
int storyProgression(char *);		// palauttaa integerin ja ottaa vastaan character osoittimen sisällön

