#include "draw.h"
#include "globals.h"
#include "bullet.h"
#include "character.h"

Draw::Draw()
{
	cout << "Draw constructor!" << endl;
}

Draw::~Draw()
{
	cout << "Draw destructor!" << endl;
}

// draw the blocks
void Draw::drawBlocks(Block ***&ptrarray, sf::Texture &blockTex, sf::RenderWindow &window)
{
	for (int a = 0; a < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; a++)
	{
		for (int b = 0; b < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; b++)
		{
			window.draw(*ptrarray[a][b]);
		}
	}
}

// draw character
void Draw::drawMole(Character &mole, sf::RenderWindow &window)
{
	window.draw(mole);
}

// draw bullets inside the linked list
void Draw::drawBullet(bulletChain *firstLink, sf::RenderWindow &window)
{
	// if the list is not empty
	if (firstLink)
	{
		bulletChain *thisLink = new bulletChain;
		thisLink = firstLink;
		// iterate through the list and draw every bullet inside
		while (thisLink->nextLink)
		{
			window.draw(thisLink->thisBullet);
			thisLink = thisLink->nextLink;
		}
		window.draw(thisLink->thisBullet);
	}
}

void Draw::drawCrosshair(Crosshair *xhair, sf::RenderWindow &window)
{
	window.draw(*xhair);
}