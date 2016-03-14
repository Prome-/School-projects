#ifndef zoneh
#define zoneh
#include <SFML/Graphics.hpp>
#include "block.h"
#include "character.h"

using namespace std;

class Zone : public sf::RectangleShape
{
public:
	Zone();
	~Zone();
	void createBitMap(Block ***&, sf::Texture *);
	void createNest(Block ***&, Character);
};

#endif