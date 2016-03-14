#include "maarittelyt.h"

int storyProgression(char *help)			// m‰‰ritell‰‰n aliohjelma joka ottaa vastaan charaacter tyyppisen osoittimen ja palauttaa kokonaisluvun
{

	string s[100];							// m‰‰ritell‰‰n string-taulukon koko
	int characterhealth;
	int choice = 0;
	int diceValue = 0;

	s[0] = "\n\nThis story takes place in a modern city in Finland, called Helsinki. A place where people go to work every day to make the wheels of the city turn. A place where creativity and the will to work coalesce into a single being. A place where everyone is happy to work and study. Except for one guy - you.";
	s[1] = "It's mid-day monday. You wake up to the realization that your electronics-project, that was supposed to be turned in last friday is still halfway done and that your upcoming math exam is thirty minutes away from starting.";
	s[2] = "You can still make it to the math exam, altough the road is going to be rough. There are beerbottles lying on the floor everywhere. The floor seems hard to pass through in your current condition. Do you want to get out of bed?";
	s[3] = "1. Yes.";
	s[4] = "2. No!";
	s[5] = "As you struggle up, you realize that someone's arm is wrapped around your waist. Your mouth curls into a grin and you look behind you, only to realize that it's actually a gargantuan swampmonster grasping your waist. Instantly your mildly inflated ego implodes in a sudden spasm into horror and you start trying to get out without waking the colossal beast.";
	s[6] = "As you relax in your bed, you realize that someone's arm is wrapped around your waist. Your mouth curls into a grin and you look behind you, only to realize that it's actually a gargantuan swampmonster grasping your waist. Instantly your mildly inflated ego implodes in a sudden spasm into horror and suddenly the math exam seems like the perfect excuse to make a run for it. You try to get out of bed without waking the colossal beast.";
	s[7] = "The monster sleeps tidily as you slip it's arm back and get up from bed. Your head is spinning like a wheel, while you pick up your clothes and head for the door.";
	s[8] = "Your shaky hand fails to remove the hand with a steady move. The beast wakes up with a monstrous yawn and sets its eyes on you - it smiles and tries to pull you back into the bed. You scream and do your best to rip yourself free.";
	s[9] = "You weren't gripped very tightly and to your joy you succeed. As you run through the door, you hear hideous moaning behind you. When you get out, you find out that in your terror-filled sprint you forgot to pick up your clothes. You check the garbage bin of your tenement to find a piece of rags, that you wrap around your bare waist.";
	s[10] = "You start walking towards your school. It's four kilometers to walk and the thought gives you a shiver. You decide to take a shortcut to make it in time, even though it's through a shady area. As your apartment begins to fade into the mass of grey buildings, a peculiar looking man jumps from behind a corner!";
	s[11] = "It's a mugger! He closes in on you with a crooked smile and a knife firmly in hand. He says: 'Your money, or your life!'\n What will you do?";
	s[12] = "1. Give him your money (saves you from a fight).";
	s[13] = "2. Don't give him anything.";
	s[14] = "Your wallet is in your pants. You don't have your pants. Fight for your life!";
	s[15] = "You hand over your wallet and the mugger walks away.";
	s[16] = "'No mugger is going to stop me from getting my shit together' you think. You still have two kilometers to walk and six minutes to do it, so you start moving yourself with your legs.";
	s[17] = "5 minutes pass.\nYou arrive to your schools doorstep. You take a second to catch your breath and start moving towards the door. You sense that there is a sinister presence lying in wait behind it. There is no time to wait, so you grit your teeth and enter.";
	s[18] = "";
	s[19] = "After the bloody fight, your heart is pounding, your throat is choking and your head is spinning. You barely make the stairs up to your math class. The class door is wide open and you lunge inside. A few grins greet you as you enter with your wheezing breath and pale face.";
	s[20] = "You sit to your designated desk and wait. Everyone seems flustered about the exam. After a short while the teacher lays the math test to your table. It looks intense. Seriously intense. You pick up your calculator, your pride and your will to survive and get ready to fight for your life!";
	s[21] = "You sit to your designated desk and wait. Everyone seems flustered about the exam. After a short while the teacher lays the math test to your table. It looks intense. Seriously intense. You reach for your calculator only to realize that it is still inside your jacket, which is at home. Saddened you pick up your pride and your will to survive and brace yourself to fight for your life.";
	s[23] = "Victory! Finally the deed is done and the slain math test rests in pieces in front of you. You roar triumphantly, pick a piece of the test as a trophy and rush out with newfound strength! There is absolutely nothing you cannot do considering what you just made through!\n\n Few years pass and you get elected for president. Another few years pass and you invent a stable and working fusion generator. The next few years? That story is for another day. Congratulations!";


	cout << s[0] << endl << endl << s[1] << endl << endl << s[2] << endl << endl << s[3] << endl << s[4] << endl << endl;

	cin >> choice;
	cout << endl << endl;

	if (choice == 1)
	{
		cout << s[5] << endl << endl;
	}
	else
	{
		cout << s[6] << endl << endl;
	}

	diceValue = diceRoll(1);	// kutsutaan aliohjelmaa jonka palautusarvo laitetaan muuttujaan diceValue

	bool clothes = true;

	if (diceValue >= 1 && diceValue <= 3)			// tulostetaan erilaisia s-taulukon paikkoja riippuen ehtolauseen toteutumisesta
	{
		cout << "You roll " << diceValue << endl << endl << s[8] << endl << endl;

		system("PAUSE");

		diceValue = diceRoll(1);
		cout << endl << "You roll " << diceValue << endl << endl << s[9] << endl << endl;
		clothes = false;
	}
	else
	{
		cout << endl << "You roll " << diceValue << endl << endl;

		system("PAUSE");

		cout << endl << s[7] << endl;
	}


	cout << s[10] << endl << endl << s[11] << endl << endl;

	if (clothes == true)
	{
		cout << s[12] << endl << s[13] << endl << endl;
		cin >> choice;
		cout << endl << endl;

		if (choice == 2)
		{
			// TAISTELU VS MUGGER
			characterhealth = combat(7, help);				// Kutsutaan aliohjelma, jolle annetaan kokonaisluku m‰‰ritt‰m‰‰n vihollisen arvoja ja helpin osoite. Aliohjelma palauttaa kokonaisluvun.
			if (characterhealth <= 0)
			{
				return 0;
			}
		}
		else
		{
			cout << s[15] << endl << endl;
		}
	}
	else
	{
		cout << s[14] << endl << endl;

		system("PAUSE");

		//TAISTELU VS MUGGER
		characterhealth = combat(7, help);					// Kutsutaan aliohjelma, jolle annetaan kokonaisluku m‰‰ritt‰m‰‰n vihollisen arvoja ja helpin osoite. Aliohjelma palauttaa kokonaisluvun.
		if (characterhealth <= 0)
		{
			return 0;
		}
	}

	cout << s[16] << endl << endl << s[17] << endl << endl;

	system("PAUSE");

	/*TAISTELU VS RANDOM ENCOUNTER*/
	characterhealth = combat(diceRoll(1), help);		// kutsutaan diceRoll-funktio, jolle annetaan parametriksi nopanheittojen m‰‰r‰ kokonaislukuna, jonka palautusarvo toimii parametrin‰ kutsussa combat-funktiolle jolle annetaan myˆs helpin osoite. T‰m‰n palautusarvo asetetaan characterhealthin arvoksi.
	if (characterhealth <= 0)
	{
		return 0;
	}

	cout << endl << endl << s[19] << endl << endl;

	if (clothes == true)
	{
		cout << s[20] << endl << endl;
		system("PAUSE");
		cout << endl;
	}

	else
	{
		cout << s[21] << endl << endl;
		system("PAUSE");
		cout << endl;
	}

	//TAISTELU VS MATIKAN KOE
	characterhealth = combat(8, help);		// kutsutaan combat funktiota, jolle annetaan parametreiksi vihollisen paikka structitaulukossa ja helpin osoite. Palautusarvo asetetaan characterhealthiin.
	if (characterhealth <= 0)
	{
		return 0;
	}
	cout << s[23] << endl << endl;
}