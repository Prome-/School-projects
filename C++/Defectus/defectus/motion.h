#ifndef motionh
#define motionh
#include <SFML/Graphics.hpp>
#include "character.h"
#include "bullet.h"
#include "crosshair.h"
#include "collision.h"
#include "block.h"

class Motion {
private:
	int permission;
public:
	void print(Character);
	Motion();
	~Motion();
	void checkMove(Character&, Block ***&);
	void move(int, Character&);
	void moveBullet(bulletChain *&);
	void turnCrosshair(Crosshair &);
	void moveCrosshair(Crosshair *, int);
	void jump(Character &, int);
};

#endif