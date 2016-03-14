#include "character.h"
#include "globals.h"



Character::Character() { //cout << "Default character constructor!" << endl;
	shotCooldown = 0;
	jumpCooldown = 0;
}
Character::~Character() { //cout << "Character destructor!" << endl; 
}

// character creation
Character::Character(std::string imgname, int xpos, sf::Texture * tex, sf::Texture *xhairTex) {

	// create an image object, load a picture into the object and load the image-object into a texture-object.
	sf::Image img;
	img.loadFromFile(imgname);
	img.createMaskFromColor(sf::Color::White);
	tex->loadFromImage(img);

	// set size, location and a texture for the character-object
	this->setSize(sf::Vector2f(20, 24));
	this->setPosition(xpos + ag::ZONE_WIDTH / 2, ag::ZONE_HEIGHT / 2);
	this->setOrigin(10, 10);
	this->setTexture(tex);

	// add a crosshair to the character-object
	Crosshair *xhair = new Crosshair();
	this->addCrosshair(xhair, xhairTex);
	shotCooldown = 0;
	jumpCooldown = 0;
	direction = 2;
}

Crosshair* Character::getCrosshair()
{
	return &this->xhair;
}

// function to insert a crosshair to a character
void Character::addCrosshair(Crosshair *newXhair, sf::Texture *xhairTex)
{
	// set crosshair position, size and texture and give the crosshair-object to the character-object
	sf::Vector2f *xhairDistance = new sf::Vector2f(20, 0);
	newXhair->setPosition(this->getPosition() + *xhairDistance);
	newXhair->setSize(sf::Vector2f(4, 4));
	newXhair->setTexture(xhairTex);
	this->xhair = *newXhair;
}

int Character::getShotCooldown()
{
	return this->shotCooldown;
}

// function responsible of limiting shot frequency
void Character::setShotCooldown()
{
	if (this->getShotCooldown() > 0)
	{
		this->shotCooldown = this->getShotCooldown() - 1;
	}
	else this->shotCooldown = 10;
}