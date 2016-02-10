#ifndef drawh
#define drawh
#include <SFML/Graphics.hpp>
#include "block.h"
#include "bullet.h"

class Draw {
public:
	Draw();
	~Draw();
	void drawBlocks(Block ***&, sf::Texture &, sf::RenderWindow &);
	void drawMole(Character &, sf::RenderWindow &);
	void drawBullet(bulletChain *, sf::RenderWindow &);
	void drawCrosshair(Crosshair *, sf::RenderWindow &);
};


#endif