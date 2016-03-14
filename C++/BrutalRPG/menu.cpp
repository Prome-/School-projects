#include "maarittelyt.h"

void menu()							// päävalikon määrittely
{
	int choice;
	char *help = NULL;				// määritetään osoittimen sisältö nulliksi
	help = new char[600];				// luodaan dynaaminen muistinvaraus helpille


	ifstream input("help.txt");			// avataan tiedosto help.txt
	if (input.is_open())				// tarkistaa onko help.txt auki
	{
		while (input.peek() != EOF)		// looppi joka kirjoittaa tekstitiedoston sisältöä muuttujaan kunnes tiedostossa loppuu sisältö
		{
			input.getline(help, 600);	// 	varsinainen kirjoitus tiedostosta
		}
	}

	else
	{
		cout << "Couldn't open help-file!";
	}

	input.close();						// sulkee tiedoston 


	cout << "EPIC BRUTAL RPG TURBO MK I" << endl << endl;
	cout << " 1 - Start game\n\n";
	cout << " 2 - Help and start game\n\n";
	cout << " 3 - Quit game\n\n";


	cin >> choice;

	


	switch (choice)						// valikko
	{
	case 1:
	{
		cout << endl << "GAME START:" << endl << endl;
		storyProgression(help);			// aliohjelmakutsu, jossa lähetetään mukana helpin muistipaikka
		break;
	}

	case 2:
	{

		cout << help << endl << endl << "GAME START:" << endl << endl;
		storyProgression(help);		// aliohjelmakutsu, jossa lähetetään mukana helpin muistipaikka
		break;

	}

	case 3:
	{
		cout << "Bye bye.";
		break;
	}
	}
	delete help;						// poistetaan dynaaminen muistinvaraus
}
