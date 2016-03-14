#include "maarittelyt.h"

int damageCount(int monsterID)		// aliohjelman m‰‰ritys, joka ottaa vastaan integerin (heitett‰vien noppien m‰‰r‰n) ja palauttaa integerin
{
	monster object = archive(monsterID);	// kutsuu aliohjelman jonka palautusarvo m‰‰ritt‰‰ objektille vahinkoarvon

	int diceValue = diceRoll(1);			// kutsuu aliohjelman jonka palautusarvo m‰‰ritt‰‰ miten lyˆnti osuu
	if (diceValue < 2)
	{
		cout << "Attack misses!" << endl << endl;
		return 0;
	}

	if (diceValue > 5)
	{
		cout << "Critical hit, dealing " << object.criticalDMG * object.damage << " points of damage" << endl << endl;
		return object.criticalDMG * object.damage;
	}

	if (1 < diceValue < 6)
	{
		cout << "Attack hits, dealing " << object.damage << " points of damage." << endl << endl;
		return object.damage;
	}
}