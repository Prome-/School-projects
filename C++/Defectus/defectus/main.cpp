#include "globals.h"
#include "game.h"
#include "bullet.h"
#include "event.h"
#include "character.h"
#include "collision.h"
#include "draw.h"
#include "motion.h"
#include "zone.h"
#include "block.h"

void main() 
{
	// initializing objects
	File newFile;
	Game newGame;
	Event newEvent;
	Zone newZone;
	Motion newMotion;
	Collision newCollision;
	Draw newDraw;
	Bullet newBullet;
	Bullet aBullet;
	sf::Clock newClock;
	
	// initializing character
	sf::Texture moleTex;
	sf::Image xhairImg;
	xhairImg.loadFromFile("prkl.png");
	sf::Texture xhairTex;
	xhairTex.loadFromImage(xhairImg);
	Character mole("mole_standing_right.png", ag::CHARACTER_DISTANCE, &moleTex, &xhairTex);

	// initializing the structure for bullets
	bulletChain *firstLink = NULL;
	sf::Texture bulletTex;

	// initializing the two-dimensional pointer-array to house block-object pointers
	Block ***ptrarray = NULL;
	sf::Image blockImg;
	blockImg.loadFromFile("Brick250a.jpg");
	sf::Texture blockTex;
	blockTex.loadFromImage(blockImg);
	newZone.createBitMap(ptrarray, &blockTex);

	// create a starting cave for the character
	newZone.createNest(ptrarray, mole);
	
	// initialize window and setup the game for takeoff
	sf::RenderWindow window(sf::VideoMode(ag::ZONE_WIDTH, ag::ZONE_HEIGHT), "Defectus");
	newGame.setStatus(1);

	newFile.ReadFromFile(false);

	// game loop
	while (window.isOpen()) {
		
		float d = newClock.restart().asSeconds();
		float transition = d * ag::GAME_SPEED;
		newEvent.handleWindow(window);
		window.clear();

		if (newGame.getStatus() == 1)
		{
			if (sf::Mouse::isButtonPressed(sf::Mouse::Left) && mole.getShotCooldown() == 0)
			{
				newBullet.addBullet(mole, firstLink, window, &bulletTex);
				mole.setShotCooldown();
			}
			newMotion.checkMove(mole, ptrarray);
			newMotion.moveBullet(firstLink);
			newCollision.checkBulletCollision(ptrarray, firstLink, newFile);
			newDraw.drawBlocks(ptrarray, blockTex, window);
			newDraw.drawMole(mole, window);
			newDraw.drawCrosshair(mole.getCrosshair(), window);
			newDraw.drawBullet(firstLink, window);
			mole.setShotCooldown();
			window.display();
		}	
	}
	newFile.WriteToFile();
	newFile.PrintAll();
}