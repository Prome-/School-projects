#ifndef digh
#define digh
#include "block.h"
#include <iostream>
using namespace std;

class Dig {

public:
	Dig();
	~Dig();
	void DirectionalDig(sf::Vector2f, string, Block***&);
private:

};

#endif