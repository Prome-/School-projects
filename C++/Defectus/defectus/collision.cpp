#include "collision.h"
#include "globals.h"
#include "bullet.h"
#include "character.h"
#include "block.h"

Collision::Collision()
{
	cout << "Collision constructor!" << endl;
}
Collision::~Collision()
{
	cout << "Collision destructor!" << endl;
}

// function responsible of checking bullet collisions on block-objects
void Collision::checkBulletCollision(Block ***&ptrarray, bulletChain *&firstLink, File &filu)
{
	// create a new struct for iterating the linked list
	bulletChain *thisLink = new bulletChain;
	thisLink = firstLink;
	if (thisLink)
	{
		// loop through the block-array
		for (int a = 0; a < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; a++)
		{
			for (int b = 0; b < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; b++)
			{
				if (thisLink)
				{
					// loop through the linked list
					while (thisLink->nextLink)
					{
						// check for collisions
						if (thisLink->thisBullet.getGlobalBounds().intersects(ptrarray[a][b]->getGlobalBounds()))
						{
							ptrarray[a][b]->setPosition(ag::ZONE_HEIGHT * 2, ag::ZONE_WIDTH * 2);
							filu.IncreaseBDestroyedCount();
							thisLink->thisBullet.removeBullet(firstLink);
						}
						thisLink = thisLink->nextLink;
					}
					// check the last struct for collisions
					if (thisLink->thisBullet.getGlobalBounds().intersects(ptrarray[a][b]->getGlobalBounds()))
					{
						ptrarray[a][b]->setPosition(ag::ZONE_HEIGHT * 2, ag::ZONE_WIDTH * 2);
						thisLink->thisBullet.removeBullet(firstLink);						
						filu.IncreaseBDestroyedCount();
					}
					thisLink = firstLink;
				}
			}
		}
	}
}

// checking character collisions on block-objects
int Collision::checkMoleCollision(Block ***& ptrarray, Character mole, int direction)
{
	// check the direction the character was planning to move and move a copy of the character to that direction.
	if (direction == 1)
	{
		mole.move(0, -1);
	}
	else if (direction == 2)
	{
		mole.move(1, 0);
	}
	else if (direction == 3)
	{
		mole.move(0, 1);
	}
	else
	{
		mole.move(-1, 0);
	}

	
	//check if the moved copy of the character collides with any blocks or if it is over the game field
	for (int a = 0; a < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; a++)
	{
		for (int b = 0; b < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; b++)
		{
			
			if (mole.getGlobalBounds().intersects(ptrarray[a][b]->getGlobalBounds()) || mole.getPosition().x > ag::ZONE_WIDTH-10 || mole.getPosition().x < 10 || mole.getPosition().y > ag::ZONE_HEIGHT-12 || mole.getPosition().y < 12)
			{
				// if yes, return 0 so the motion knows not to move the character
				return 0;
			}
		}
	}
	// no collisions, character is free to move
	return 1;
}