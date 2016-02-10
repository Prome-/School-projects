#ifndef blockh
#define blockh
#include <SFML/Graphics.hpp>
#include "globals.h"

class Block : public sf::RectangleShape
{
public:
	Block(sf::Vector2f);
	~Block();
};





#endif