#include "motion.h"
#include "globals.h"
#include "character.h"
#include "bullet.h"
#include "crosshair.h"

Motion::Motion() 
{
	this->permission = 0;
	cout << "Motion constructor!" << endl;
}

Motion::~Motion()
{
	cout << "Motion destructor!" << endl;
}

// function responsible for character jump
void jump(Character mole, int jumpCooldown)
{

	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Space) && jumpCooldown == 0)
	{
		// todo
	}
}

// function for checking permission for moving and calling move
void Motion::checkMove(Character &mole, Block ***&ptrarray) {

	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Up)) {

		permission = Collision::checkMoleCollision(ptrarray, mole, 1);
		if(permission == 1)
		{
			move(0, mole);
			moveCrosshair(mole.getCrosshair(), 1);
			
		}
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Right)) {
		permission = Collision::checkMoleCollision(ptrarray, mole, 2);
		
		if (permission == 1)
		{
			move(1, mole);
			moveCrosshair(mole.getCrosshair(), 2);
			if (mole.direction == 4)
			{
				mole.scale(-1, 1);
				mole.direction = 2;
				mole.getCrosshair()->move(40,0);
			}
			
		}
	}
	if (/*sf::Keyboard::isKeyPressed(sf::Keyboard::Down)*/true) {		//painovoiman pakottaminen, alaspäin liikkuminen aina true
		permission = Collision::checkMoleCollision(ptrarray, mole, 3);
		
		if (permission == 1)
		{
			move(2, mole);
			moveCrosshair(mole.getCrosshair(), 3);
		}
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Left)) {
		permission = Collision::checkMoleCollision(ptrarray, mole, 4);
		
		if (permission == 1)
		{
			move(3, mole);
			moveCrosshair(mole.getCrosshair(), 4);
		}
		if (mole.direction == 2)
		{
			mole.scale(-1, 1);
			mole.direction = 4;
			mole.getCrosshair()->move(-40, 0);
		}
	}
}

// function to move the character
void Motion::move(int button, Character &mole) {

	switch (button) {

	case 0:
		// pressed up
		mole.move(0, -1);
		print(mole);
		break;
	case 1:
		// pressed right
		mole.move(1, 0);
		print(mole);
		break;
	case 2:
		// pressed down
		mole.move(0, 1);
		print(mole);
		break;
	case 3:
		// pressed left
		mole.move(-1, 0);
		print(mole);
		break;
	}
}

void Motion::print(Character mole) {	//print function for character position

	sf::Vector2f pos = mole.getPosition();

	int x, y;

	x = pos.x;
	y = pos.y;
}

// function to move the bullets in the linked list
void Motion::moveBullet(bulletChain *&firstLink)
{
	bulletChain *thisLink = new bulletChain;
	thisLink = firstLink;
	if (thisLink)
	{
		while (thisLink->nextLink)
		{
			thisLink->thisBullet.setPosition(thisLink->thisBullet.getPosition() + thisLink->thisBullet.getDirection());
			thisLink = thisLink->nextLink;
		}
		thisLink->thisBullet.setPosition(thisLink->thisBullet.getPosition() + thisLink->thisBullet.getDirection());
	}
}

void Motion::turnCrosshair(Crosshair &xhair)
{
	// todo
}

// function to move crosshair
void Motion::moveCrosshair(Crosshair *xhair, int direction)
{
	if (direction == 1)
	{
		xhair->move(0,-1);
	}
	else if (direction == 2)
	{
		xhair->move(1, 0);
	}
	else if (direction == 3)
	{
		xhair->move(0, 1);
	}
	else xhair->move(-1, 0);
}