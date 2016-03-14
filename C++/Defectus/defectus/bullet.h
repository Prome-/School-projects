#ifndef bulleth
#define bulleth
#include <SFML/Graphics.hpp>
#include "character.h"

class Bullet : public sf::RectangleShape
{
	public:
		Bullet();
		Bullet(int, int, sf::Texture *);
		~Bullet();
		static int addBullet(Character, struct bulletChain *&, sf::RenderWindow &, sf::Texture *);
		void removeBullet(bulletChain *&);
		void setVector(sf::Vector2f);
		void determineVectors(Character, sf::RenderWindow &, Bullet &);
		sf::Vector2f determineAngle(sf::Vector2f, sf::Vector2f);
		sf::Vector2f getDirection();
	private:
		sf::Vector2f direction;
		bulletChain *myLink;
};


struct bulletChain
{
	Bullet thisBullet;
	bulletChain *nextLink;
	bulletChain *lastLink;
};

#endif