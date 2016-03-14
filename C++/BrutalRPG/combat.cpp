#include "maarittelyt.h"

int combat(int monsterID, char *help)					// aliohjelmam‰‰ritelm‰, ottaa vastaan integerin ja characterin ja palauttaa integerin
{
	int damage;
	monster enemy;										// m‰‰ritet‰‰n vihollismuuttuja mallia monster struct
	monster character;									// m‰‰ritell‰‰n pelaajamuuttuja mallia monster struct

	enemy = archive(monsterID);							// aliohjelmakutsu archivelle, joka palauttaa arvot viholliselle
	character = archive(0);								// aliohjelmakutsu archivelle, joka palauttaa arvot pelaajalle

	bool combatOn = true;
	bool playerturn = true;

	while (combatOn == true)							// looppi joka pyˆrii niin kauan kuin combatOn on tosi
	{
		int action;
		cout << "Encounter with a wild " << enemy.name << endl << endl << endl;

		cout << "	" << character.name << endl << endl << "	HP: " << character.health << endl << "	DMG: " << character.damage << endl << "	Critical hit chance: " << character.criticalChance << endl << endl << endl;
		cout << "	" << enemy.name << endl << endl << "	HP: " << enemy.health << endl << "	DMG: " << enemy.damage << endl << "	Critical hit chance: " << enemy.criticalChance << endl << endl << endl;

		system("PAUSE");
		cout << "It's your turn! What is your action?" << endl << endl << "1. Attack" << endl << "2. Defend" << endl << "3. Give up" << endl << "4. Help" << endl << endl;
		cin >> action;
		playerturn = true;

		if (action == 1) // pelaaja lyˆ
		{
			damage = damageCount(0);					// kutsutaan aliohjelma, jolle annetaan pelaajan structin vahinkoarvo, joka palauttaa tehdyn vahingon damage-arvoon
			enemy.health = enemy.health - damage;		// vihollisen terveydest‰ v‰hennet‰‰n damage
			cout << "Enemy health: " << enemy.health;	// uusi terveysarvo tulostetaan
			cout << endl;
			playerturn = false;							// pelaajan vuoro p‰‰ttyy
		}

		if (action == 2) // lopettaa pelaajan vuoron ja jakaa seuraavalla vuorolla tulevan vahingon kahdella
		{
			cout << "Enemy turn!\n\n";
			system("PAUSE");
			cout << "Enemy attacks!\n\n";

			damage = damageCount(monsterID) / 2;				// aliohjelmakutsu, jossa aliohjelmalle annetaan vihollisen structin vahinkoarvo ja jaetaan palautusarvo kahdella
			character.health = character.health - damage;	// v‰hennet‰‰n pelaajan terveydest‰ tehty vahinko
			cout << "Your health: " << character.health << endl << endl;	// tulostetaan uusi terveysarvo

		}

		if (action == 3) // lopettaa pelin asettamalla pelaajan terveyden nollaan
		{
			cout << endl << "The world dims around you as your flailing head descends towards the ground. It welcomes you and you to its cold, hard embrace and feel your life-force fading into the ether. Game over mate.\n\n";

			character.health = 0;
			return character.health;	// palauttaa terveysarvon storyProgressionille, jossa on myˆs if-lause pelaajan terveyden ollessa nolla joka ohjaa kaikki aliohjelmat loppuun
		}

		if (action == 4)				// help-osoitteen sis‰llˆn tulostus
		{
			cout << help;
		}

		if (enemy.health <= 0)			// lopettaa aliohjelman jos vihollisen terveys on alle tai tasan nolla
		{
			cout << endl << "You have slain " << enemy.name << "!" << endl << endl;
			system("PAUSE");
			cout << endl;
			return character.health;	// palauttaa hahmon terveyspisteet storyProgressionille
		}

		if (playerturn == false)		// ehtolause joka antaa viholliselle vuoron toteutuessaan
		{

			cout << "Enemy turn!\n\n";
			system("PAUSE");
			cout << "Enemy attacks!\n\n";

			damage = damageCount(monsterID);			// Kutsuu damageCount-funktiota ja antaa sille parametriksi strucitaulukkopaikan arvon jolla aliohjelma laskee tehdyn vahingon. Palautusarvo asetetaan damage-muuttujaan.
			character.health = character.health - damage;
			cout << "Your health: " << character.health << endl << endl;
		}

		if (character.health <= 0)		// palauttaa terveysarvon storyProgressionille, jossa on myˆs if-lause pelaajan terveyden ollessa nolla joka ohjaa kaikki aliohjelmat loppuun
		{
			cout << "The world dims around you as your flailing head descends towards the earths crust. It welcomes you and you to its cold embrace and feel your life-force fading into the ether. Game over mate.\n\n Restart?\n\n1.Yes\n2No.";
			return character.health;
		}
	}
}