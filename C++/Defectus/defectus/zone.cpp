#include "zone.h"
#include "globals.h"


Zone::Zone()
{
	cout << "Zone konstruktori!" << endl;
}

Zone::~Zone()
{
	cout << "Zone destruktori!" << endl;
}

 
 // this method adds Block-objects to a two-dimensional array using pointers.
 // the method is given a pointer to a pointer to a pointer by reference as a parameter
void Zone::createBitMap(Block ***& ptrarray, sf::Texture *blockTex) 
{
	// the first pointer is set to point to a one-dimensional array of pointers of pointers of Block-type objects
	ptrarray = new Block** [ag::ZONE_HEIGHT];

	// the array is filled with pointers to arrays that will be filled with pointers to the objects themselves
	for (int a = 0;a < ag::ZONE_HEIGHT/ag::BLOCK_HEIGHT;a++)
	{
		ptrarray[a] = new Block*[ag::ZONE_WIDTH/ag::BLOCK_WIDTH];
	}

	// filling the arrays inside the array with pointers to Block-type objects
	for (int a = 0; a < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT;a++)
	{
		for (int b = 0; b < ag::ZONE_WIDTH/ag::BLOCK_WIDTH;b++)
		{
			ptrarray[a][b] = new Block(sf::Vector2f(ag::BLOCK_WIDTH, ag::BLOCK_HEIGHT));
			ptrarray[a][b]->setTexture(blockTex);
			ptrarray[a][b]->setPosition(a*ag::BLOCK_HEIGHT, b*ag::BLOCK_WIDTH);
		}	
	}
}

// function to create the starting cave for the character
void Zone::createNest(Block ***& ptrarray, Character mole)
{
	// check for collisions and remove blocks that collide with the character rectangle
	for (int a = 0; a < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; a++)
	{
		for (int b = 0; b < ag::ZONE_HEIGHT / ag::BLOCK_HEIGHT; b++)
		{
			
			if (mole.getGlobalBounds().intersects(ptrarray[a][b]->getGlobalBounds()))
			{
				ptrarray[a][b]->setPosition(sf::Vector2f(5000, 5000));
			}
		}
	}
}
