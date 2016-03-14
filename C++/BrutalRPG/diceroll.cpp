#include "maarittelyt.h"

int diceRoll(int numberOfThrows)	// aliohjelman m‰‰ritys, joka ottaa vastaan heittojen m‰‰r‰n, eli integerin ja palauttaa niiden tuloksen
{

	int result = 0;

	srand(time(NULL));				// kutsuu time-funktiota, NULL-parametrilla, jonka palautusarvolla kutsutaan srand-funktiota. Tuloksena saadaan j‰rjestelm‰n aika-arvosta johdettu pseudorandom-arvo.

	for (int i = 0; i < numberOfThrows; i++)		// looppi joka arpoo diceRollin kutsussa m‰‰ritetyn parametrin arvon verran lukuja
	{
		result = (rand() % 6 + 1);					// arpoo 0...5 + 1
	}

	return result;						// palauttaa tuloksen combatille
}