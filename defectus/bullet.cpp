#include "bullet.h"
#include "globals.h"
#include "character.h"

Bullet::Bullet(int xpos, int ypos, sf::Texture *bulletTex)
{
	cout << "Bullet overloaded constructor!" << endl;
	this->setSize(sf::Vector2f(4, 2));
	this->setPosition(xpos, ypos);
	this->setTexture(bulletTex);
}

Bullet::Bullet()
{ 
	this->setSize(sf::Vector2f(4, 2));
};

Bullet::~Bullet()
{
	cout << "Bullet destructor!" << endl;
}


// create a struct, which has a Bullet-object, and add it to a linked list for collision checking

int Bullet::addBullet(Character mole, bulletChain *&firstLink, sf::RenderWindow &window, sf::Texture *bulletTex)
{
	// create the stuct and add a position and a direction to the bullet-object inside it
	bulletChain *newLink = new bulletChain;
	newLink->thisBullet.setPosition(mole.getPosition());
	newLink->thisBullet.determineVectors(mole, window, newLink->thisBullet);

	sf::Image bulletImage;
	bulletImage.loadFromFile("bullet.png");
	bulletTex->loadFromImage(bulletImage);
	
	newLink->thisBullet.setFillColor(sf::Color::White);
	//newLink->thisBullet.setTexture(bulletTex);
	//the bullet is given knowledge which struct it is inside of
	newLink->thisBullet.myLink = newLink;

	// adding the struct to the two-way linked list
	if (newLink) 
	{
		newLink->nextLink = NULL;
		newLink->lastLink = NULL;
		// if the list is empty, make the new struct the first link
		if (!firstLink) { firstLink = newLink; }
		else 
		{
			// if the list is not empty, find the last struct of the list and link the new struct in the end of the chain
			bulletChain *thisLink = new bulletChain;
			thisLink = firstLink;
			while (thisLink->nextLink)
			{
				thisLink = thisLink->nextLink;
			}
			thisLink->nextLink = newLink;
			newLink->lastLink = thisLink;
		}
		return 1;
	}

	return 0;
}

void Bullet::setVector(sf::Vector2f newDirection)
{
	this->direction = newDirection;
}

void Bullet::determineVectors(Character mole, sf::RenderWindow &window, Bullet &newBullet)
{
	
	sf::Vector2f moleVector = mole.getPosition();
	// since sf::Mouse::getPosition() returns an integer vector, it has to be cast into a float vector
	sf::Vector2f mouseVector;

	float x = 0;
	float y = 0;

	y = sf::Mouse::getPosition(window).y;
	x = sf::Mouse::getPosition(window).x;
	mouseVector = sf::Vector2< float >::Vector2(x, y);

	// combine the two vectors to a single one
	sf::Vector2f bulletVector = determineAngle(mouseVector, moleVector);

	// set the vector to the bullet
	newBullet.setVector(bulletVector);
}

// calculate the direction and speed of the projectile based on the positions of the shooter and the cursor
sf::Vector2f Bullet::determineAngle(sf::Vector2f mouseVector, sf::Vector2f moleVector)
{
	
	sf::Vector2f bulletVector = mouseVector - moleVector;

	// if the cursor is exactly on the character
	if (bulletVector.x == 0 && bulletVector.y == 0)
	{
		bulletVector.x = 1;
	}
	return bulletVector;
}

sf::Vector2f Bullet::getDirection()
{
	return this->direction;
}

// remove the struct from the linked list and destroy the bullet-object inside it
// and repair the chain of links
void Bullet::removeBullet(bulletChain *&firstLink)
{
	// check if the struct is the first link of the list
	if (this->myLink != firstLink)
	{
		// check if the struct is not the last link of the linked list
		if (this->myLink->nextLink)
		{
			// the struct is between other structs
			this->myLink->lastLink->nextLink = this->myLink->nextLink;
			this->myLink->nextLink->lastLink = this->myLink->lastLink;
			this->~Bullet();
		}
		else
		{
			// the struct is the last struct
			{
				this->myLink->lastLink->nextLink = NULL;
				this->~Bullet();
			}
		}
	}
	else
	{
		// check if it is the only one in the list
		if (this->myLink->nextLink)
		{
			// the struct is the first struct and is not alone in the list
			firstLink = firstLink->nextLink;
			firstLink->lastLink = NULL;
			this->~Bullet();
		}
		else
		{
			// the struct is the only struct in the list
			firstLink = NULL;
			this->~Bullet();
		}

	}
}