#ifndef collisionh
#define collisionh
#include <SFML/Graphics.hpp>
#include "block.h"
#include "character.h"
#include "bullet.h"
#include "file.h"



class Collision
{
public:
	Collision();
	~Collision();
	static int checkMoleCollision(Block ***&, Character, int);
	void checkBulletCollision(Block ***&, bulletChain *&, File&);

};


#endif