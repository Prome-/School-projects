#include "block.h"

Block::Block(sf::Vector2f vector)
{
	cout << "Block constructor!" << endl;
	this->setSize(vector);
}

Block::~Block()
{
	cout << "Block destructor!" << endl;
}