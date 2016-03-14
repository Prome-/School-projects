#include "maarittelyt.h"

monster archive(int monsterID)			// aliohjelmam‰‰ritelm‰, joka palauttaa structin ja ottaa vastaan integerin
{
	monster object[9];

	object[0] = { "You, the motherlands hope", 200, 10, 2, 2 };
	object[1] = { "King Slime", 100, 2, 4, 1 };
	object[2] = { "Batman", 50, 5, 2, 2 };
	object[3] = { "Sodomite", 30, 3, 2, 2 };
	object[4] = { "Fiona the feminist", 20, 2, 2, 2 };
	object[5] = { "Kodos the alien", 60, 4, 2, 2 };
	object[6] = { "Angry jew", 35, 10, 2, 2 };
	object[7] = { "Mugger", 20, 14, 3, 3 };
	object[8] = { "Math test", 100, 8, 2, 2 };

	switch (monsterID)
	{
	case 0:
		return object[0];
		break;
	case 1:
		return object[1];
		break;
	case 2:
		return object[2];
		break;
	case 3:
		return object[3];
		break;
	case 4:
		return object[4];
		break;
	case 5:
		return object[5];
		break;
	case 6:
		return object[6];
		break;
	case 7:
		return object[7];
		break;
	case 8:
		return object[8];
		break;
	}
}

