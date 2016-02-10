#include "dig.h"

// Riippuvainen crosshair luokasta. Crosshair luokka jätettiin kesken Arin palautteen vuoksi, eli ei olisi tuonut lisäarvoa arvostelun näkökulmasta. 
// Myyrän kaivuuluokka Dig toteutettiin, mutta jätettiin implementoimatta riippuvuuden vuoksi. Koodi kuitenkin testattua ja toiminnallista "dummy" tähtäimellä.

//muodostaa myyrän eteen myyrän kokoisen näkymättömän neliön, jonka kulma on sama, kuin tähtäimen kulma. Nappia painettaessa näkymättömän neliön alueelta katsotaan collisionissa global bounds
//ja collision sääntöjen mukana poistetaan, eli "kaivetaan" pois neliön alueella olevat palikat. 
Dig::Dig() {
}
void Dig::DirectionalDig(sf::Vector2f player, string direction, Block ***&ptrarray) {/*

	sf::Vector2f digAreaLocation;
	sf::Vector2f digAreaSize;

	digAreaLocation.x = player.x + 20;
	digAreaLocation.y = player.y;

	digAreaSize.x = player.x + 20;
	digAreaSize.y = player.y + 24;

	sf::RectangleShape *digArea = new sf::RectangleShape(digAreaLocation);

	digArea->setSize(digAreaSize);
	
	digArea->setRotation(atan2(crosshair.y - player.y, crosshair.x - player.x)); 

	digArea->setOutlineColor(sf::Color::Green);
	
	if (player.x <= ag::ZONE_WIDTH/2 && player.y <= ag::ZONE_HEIGHT/2) {
		//vasen yläsektori
		funktio();
	}
	if (player.x <= ag::ZONE_WIDTH/2 && player.y > ag::ZONE_HEIGHT/2) {
		//vasen alasektori
		funktio();
	}
	if (player.x > ag::ZONE_WIDTH/2 && player.y <= ag::ZONE_HEIGHT/2) {
		//oikea yläsektori
		funktio();
	}
	if (player.x > ag::ZONE_WIDTH/2 && player.y < ag::ZONE_HEIGHT/2) {
		//oikea alasektori
		funktio();
	}*/
}

void funktio(int x, int y) {
/*
	for (int a = 0; ;a++) {
		for (int b = 0; b < ag::ZONE_WIDTH / ag::BLOCK_WIDTH;b++) {
			ptrarray[a][b] = new Block(sf::Vector2f(ag::BLOCK_WIDTH, ag::BLOCK_HEIGHT));
			ptrarray[a][b]->setPosition(a*ag::BLOCK_HEIGHT, b*ag::BLOCK_WIDTH);
		}
	}
	*/
}