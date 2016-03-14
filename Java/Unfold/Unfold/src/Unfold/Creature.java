package Unfold;

import java.util.ArrayList;


/**
 * Contains all the functionality and data for interactive creatures within the simulation.
 * 
 * @author Aleksi Tommila
 * @author Janne Möttölä
 * 
 */
public class Creature {
    
    private Square[][] copiedSquares;
    private ArrayList<Creature> copiedCreatures = new ArrayList<Creature>();
    private ArrayList<Creature> inhabitants = new ArrayList<Creature>();
    private ArrayList<Creature> potentialPrey = new ArrayList<Creature>();
    private ArrayList<Creature> unfitPrey = new ArrayList<Creature>();
            
    private int columns, rows, x, y, id, diet, isFlying, hasHerd, isBurrower, hasFangs,
            hasClaws, canProwl, hasTusks, temperaturePreference, reproductivity, size, infertileCycles;
    
    private static int lastId;
    
    private double foodWhereIStand, temperatureWhereIStand, shelterWhereIStand, anxIndex,
            energyExpenditure, energyConsumption, energyReserve, energyReserveMax, carcassEnergyValue; 
    
    private boolean foundPrey, doneOnce, hasBred;
    
    
    /**
     * 
     * Constructor for the class, fills local variables with randomized and received data. 
     * 
     * @param x x-coordinate of creature location on the square grid.
     * @param y y-coordinate of creature location on the square grid.
     * @param id unique of this creature instance
     * @param rows amount of rows in the simulation area.
     * @param columns amount of columns in the simulation area.
     */
    
    public Creature(int x, int y, int id, int rows, int columns){
        
        this.x = x;
        this.y = y;
        this.id = id;
        
        if (id>lastId) lastId = id;
        
        this.columns = columns;
        this.rows = rows;
        
        diet  = (int) (Math.random() * 2);
        isFlying = (int) (Math.random() * 2);
        hasHerd = (int) (Math.random() * 2);
        isBurrower = (int) (Math.random() * 2);
        hasFangs = (int) (Math.random() * 2);
        hasClaws = (int) (Math.random() * 2);
        canProwl = (int) (Math.random() * 2);
        hasTusks = (int) (Math.random() * 2);
        temperaturePreference = (int)(Math.random()*20+5);
        reproductivity = (int) (Math.random()*3+1);
        size = (int) (Math.random() * 5);
        
        energyExpenditure = 1;
        energyConsumption = energyExpenditure + 5;
        energyReserve = 40;
        energyReserveMax = size * 10 + 100;
        carcassEnergyValue = energyExpenditure * 20 + energyReserve;
        
        
        System.out.println("Creature with ID: " + id + " has been created. He has: ");
        System.out.println("Coordinates: [" + x + "][" + y + "]");
        System.out.println("Diet: " + diet);
        
    } 
    
    public Creature(int x, int y, int id, int rows, int columns, int[] offspringFeatures)
    {
        this.x = x;
        this.y = y;
        this.id = id;
        
        this.rows = rows;
        this.columns = columns;
        
        if (id>lastId) lastId = id;
        
        diet = offspringFeatures[0];
        isFlying = offspringFeatures[1];
        hasHerd = offspringFeatures[2];
        isBurrower = offspringFeatures[3];
        hasFangs = offspringFeatures[4];
        hasClaws = offspringFeatures[5];
        canProwl = offspringFeatures[6];
        hasTusks = offspringFeatures[7];
        temperaturePreference = offspringFeatures[8];
        reproductivity = offspringFeatures[9];
        size = offspringFeatures[10];     
        
        energyExpenditure = 1;
        energyConsumption = energyExpenditure + 5;
        energyReserve = 40;
        energyReserveMax = size * 10 + 100;
        carcassEnergyValue = energyExpenditure * 20 + energyReserve;
        
        infertileCycles = 40;
        hasBred = true;
        
        System.out.println("A creature has been born with id: " + id);
    }
    
    /**
     * Creature action start. Starts creatures AI simulation. Receives relevant data of other creatures and its location within the simulation. 
     * 
     * @param originalSquares the square table as it is before the activation of this creature.
     * @param originalCreatures the creatures ArrayList as it is before the activation of this creature. 
     * @param columns amount of columns in the simulation area.
     * @param rows amount of rows in the simulation area.
     * @param x x-coordinate of creature location on the square grid.
     * @param y y-coordinate of creature location on the square grid.
     * @return returns itself.
     */
    
    public Creature runCreature(Square[][] originalSquares,ArrayList<Creature> originalCreatures, int columns, int rows, int x, int y){

        if (hasBred == true)
        {
            if(doneOnce == false)
            {
                doneOnce = true;
                infertileCycles = 40;
            }
        }
        
        if (infertileCycles > 0) infertileCycles--;
        else 
        {
            hasBred = false;
            doneOnce = false;
        }
        
        System.out.println("***************************");
        System.out.println("I am Creature: " + id);
        System.out.println("My diet is: " + diet);
        System.out.println("My stored energy is: " + energyReserve);
        System.out.println("My energy expenditure is: " + energyExpenditure);
        System.out.println("My energy consumption is: " + energyConsumption);
        
        copiedSquares = originalSquares;
        copiedCreatures = originalCreatures;
        
        this.x = x;
        this.y = y;
        
        potentialPrey.removeAll(potentialPrey);
            
        lookAtLocation();
        anxIndex = determineAnxiousness();
        
        if (determineThreat())
        {
            System.out.print("I'm moving ");
            move();
        } else {
            
            determineAction();
        }      
        return this;
    }
    
    private void lookAtLocation(){
        
        System.out.println("I am lookin at the square I'm standing on with coords [" + x +"][" + y + "]");
        
        foodWhereIStand = copiedSquares[x][y].getFood();
        temperatureWhereIStand = copiedSquares[x][y].getTemperature();
        shelterWhereIStand = copiedSquares[x][y].getShelter();
        inhabitants = copiedSquares[x][y].getInhabitants();
        
        System.out.println("    Food here: " + foodWhereIStand + "\n    Temperature here: " + temperatureWhereIStand + "\n    Shelter here: " + shelterWhereIStand);
    }
    
    private double determineAnxiousness(){
       
        System.out.println("I am determining my anxiousness:");
        
        anxIndex = 0;
        
        anxIndex = determineHungerAnx();
        anxIndex = determineShelterAnx();
        anxIndex = determineTempAnx();
        
        return anxIndex;
    }
    
    private double determineHungerAnx(){
        
        if(diet == 0){                                                          //If herbivore
            if(foodWhereIStand < energyExpenditure){                            //If food in my square is less than what I need for this turn               
                    anxIndex = anxIndex + 100;
            }
                                                                                //If enough food for this turns expenditure, but less than the creature would like to eat
            if (foodWhereIStand >= energyExpenditure && foodWhereIStand < energyConsumption){
                anxIndex = anxIndex + 10;
            }
        }

        if(diet == 1){                                                          //If carnivore
            if (energyReserve < 40){                                            //If running low on energy
                anxIndex = anxIndex+100;
            }
        }
        
        System.out.println("    My anxiety from hunger is: " + anxIndex);
        
        return anxIndex;
    }

    private double determineShelterAnx(){
        
        if(shelterWhereIStand < 90){
            anxIndex = anxIndex + 10;           
            if(shelterWhereIStand < 70){
                anxIndex = anxIndex + 10;
                if(shelterWhereIStand < 50){
                    anxIndex = anxIndex + 10;
                    if(shelterWhereIStand < 30){
                        anxIndex = anxIndex + 10;
                        if(shelterWhereIStand < 10){
                            anxIndex = anxIndex + 10;
                        }
                    }
                }
            }
        }
        System.out.println("    My anxiety with available shelter considered is: " + anxIndex);
        return anxIndex;
    }    
    
    private double determineTempAnx(){
        
        if(temperatureWhereIStand >= temperaturePreference + 5 || temperatureWhereIStand <= temperaturePreference - 5)
        {
            anxIndex = anxIndex + 10;
            if (temperatureWhereIStand >= temperaturePreference + 10 || temperatureWhereIStand <= temperaturePreference - 10)
            {
                anxIndex = anxIndex + 10;
                if (temperatureWhereIStand >= temperaturePreference + 15 || temperatureWhereIStand <= temperaturePreference - 15)
                {
                    anxIndex = anxIndex + 20;
                    if (temperatureWhereIStand >= temperaturePreference + 20 || temperatureWhereIStand <= temperaturePreference - 20)
                    {
                        anxIndex = anxIndex + 20;
                    }
                }
            }
        }
        System.out.println("    My anxiety with the temperature considered is: " + anxIndex);
        return anxIndex;
    }
    
    private boolean determineThreat(){
        
        System.out.println("I am determining if there are threats to me in this square.");
        
        for(int i = 0; i < inhabitants.size(); i++){
            if(diet == 1 && inhabitants.get(i).getId() != id && inhabitants.get(i).getSize() >= size
               || inhabitants.get(i).getId() != id && inhabitants.get(i).getHasHerd() == 1 && hasHerd == 0){
                System.out.println("There is at least one threat to me in my square. His ID is: " + inhabitants.get(i).getId());
                return true;
            }
        }
        System.out.println("There are no threats present.");
        return false;
    }
    
    private void determineMate(){
        System.out.println("Determining possible mates.");

        for(int i = 0; i <inhabitants.size();i++)
        {
            if(compareMateFeatures(inhabitants.get(i).getMateFeatures()) > 0 && hasBred == false && inhabitants.get(i).getHasBred() == false && reproductivity > 0 && inhabitants.get(i).getReproductivity() > 0 && id != inhabitants.get(i).getId())
            {
                System.out.println("I am " +id+ "and I make babies with " + inhabitants.get(i).getId() + "my reroductvity is: " + reproductivity + " and my mates reproductivity is: "+inhabitants.get(i).getReproductivity());
                for(int babies = 0;babies <= reproductivity;babies++)
                {
                    copiedCreatures.add(new Creature(getX(), getY(), lastId+1, rows, columns, offspringFeatures(i)));
                }
                hasBred = true;
                inhabitants.get(i).hasBred = true;
                break;
            }
        }
    }
    
    private int[] getMateFeatures(){
        int[] mateFeatures = new int[11];
        
        mateFeatures[0] = diet;
        mateFeatures[1] = isFlying;
        mateFeatures[2] = hasHerd;
        mateFeatures[3] = isBurrower;
        mateFeatures[4] = hasFangs;
        mateFeatures[5] = hasClaws;
        mateFeatures[6] = canProwl;
        mateFeatures[7] = hasTusks;
        mateFeatures[8] = temperaturePreference;
        mateFeatures[9] = reproductivity;
        mateFeatures[10] = size;
        
        return mateFeatures;
    }
    
    private int compareMateFeatures(int[] mateFeatures){
        int equalityIndex = 0;
        
        if(mateFeatures[0] != diet) return 0;
        
        if(mateFeatures[1] == isFlying) equalityIndex++;
        else equalityIndex--;
        
        if (mateFeatures[2] == hasHerd) equalityIndex++;
        else equalityIndex--;
        
        if (mateFeatures[3] == isBurrower) equalityIndex++;
        else equalityIndex--;
        
        if(mateFeatures[4] == hasFangs) equalityIndex++;
        else equalityIndex--;
        
        if(mateFeatures[5] == hasClaws) equalityIndex++;
        else equalityIndex--;
        
        if(mateFeatures[6] == canProwl) equalityIndex++;
        else equalityIndex--;
        
        if(mateFeatures[7] == hasTusks) equalityIndex++;
        else equalityIndex--;
        
        if (mateFeatures[8] <= temperaturePreference+10 || mateFeatures[8] >= temperaturePreference-10) equalityIndex++;
        else equalityIndex--;
        
        if (mateFeatures[9] <= reproductivity+3 || mateFeatures[9] >= reproductivity-3) equalityIndex++;
        else equalityIndex--;
        
        if(mateFeatures[10] <= size+2 || mateFeatures[10] >= size-2) equalityIndex++;
        else equalityIndex--;
        
        return equalityIndex;
    }
    
    private int[] offspringFeatures(int iterator){
       
        int[] offspringFeatures = new int[11];
        int inheritanceRand = (int) Math.random() * 2;
        
        if (diet == inhabitants.get(iterator).getDiet()) offspringFeatures[0] = diet;
        else offspringFeatures[0] = (int) Math.random() * 2;
        
        if (isFlying == inhabitants.get(iterator).getIsFlying()) offspringFeatures[1] = isFlying;
        else offspringFeatures[1] = (int) Math.random() * 2;
        
        if (hasHerd == inhabitants.get(iterator).getHasHerd()) offspringFeatures[2] = hasHerd;
        else offspringFeatures[2] = (int) Math.random() * 2;

        if (isBurrower == inhabitants.get(iterator).getIsBurrower()) offspringFeatures[3] = isBurrower;
        else offspringFeatures[3] = (int) Math.random() * 2;

        if (hasFangs == inhabitants.get(iterator).getHasFangs()) offspringFeatures[4] = hasFangs;
        else offspringFeatures[4] = (int) Math.random() * 2;
        
        if (hasClaws == inhabitants.get(iterator).getHasClaws()) offspringFeatures[5] = hasClaws;
        else offspringFeatures[5] = (int) Math.random() * 2;

        if (canProwl == inhabitants.get(iterator).getCanProwl()) offspringFeatures[6] = canProwl;
        else offspringFeatures[6] = (int) Math.random() * 2;

        if (hasTusks == inhabitants.get(iterator).getHasTusks()) offspringFeatures[7] = hasTusks;
        else offspringFeatures[7] = (int) Math.random() * 2;
        
        if (temperaturePreference == inhabitants.get(iterator).getTemperaturePreference()) offspringFeatures[8] = temperaturePreference;
        else
        {
            int temperaturePreferenceMax, temperaturePreferenceMin;
            
            if (temperaturePreference > inhabitants.get(iterator).getTemperaturePreference())
            {
                temperaturePreferenceMax = temperaturePreference+inheritanceRand;
                temperaturePreferenceMin = inhabitants.get(iterator).getTemperaturePreference() - inheritanceRand;
            }
            else
            {
                temperaturePreferenceMax = inhabitants.get(iterator).getTemperaturePreference() + inheritanceRand;
                temperaturePreferenceMin = temperaturePreference -inheritanceRand;
            }

            offspringFeatures[8] = (int) (Math.random() * temperaturePreferenceMax) +1;

            while(offspringFeatures[8] < temperaturePreferenceMin) offspringFeatures[8] = (int) (Math.random() * temperaturePreferenceMax) +1;        
        }
        
        if (reproductivity == inhabitants.get(iterator).getReproductivity()) offspringFeatures[9] = reproductivity;
        else
        {
            int reproductivityMax, reproductivityMin;

            if(reproductivity > inhabitants.get(iterator).getReproductivity())
            {
                reproductivityMax = reproductivity+inheritanceRand;
                reproductivityMin = inhabitants.get(iterator).getReproductivity() - inheritanceRand;
            }
            else 
            {
                reproductivityMax = inhabitants.get(iterator).getReproductivity() + inheritanceRand;
                reproductivityMin = reproductivity - inheritanceRand;
            }

            offspringFeatures[9] = (int) (Math.random() * reproductivityMax)+1;

            while(offspringFeatures[9] < reproductivityMin) offspringFeatures[9] = (int) (Math.random() * reproductivityMax)+1;                
        }

        if (size == inhabitants.get(iterator).getSize()) offspringFeatures[10] = size;
        else
        {
            int sizeMax, sizeMin;
            
            if(size > inhabitants.get(iterator).getSize())
            {
                sizeMax = size+inheritanceRand;
                sizeMin = inhabitants.get(iterator).getSize() - inheritanceRand;
            }
            else
            {
                sizeMax = inhabitants.get(iterator).getSize() + inheritanceRand;
                sizeMin = size - inheritanceRand;
            }
            
            offspringFeatures[10] = (int) (Math.random() * sizeMax) +1;
            
            while(offspringFeatures[10] < sizeMin) offspringFeatures[10] = (int) (Math.random() * sizeMax) +1;
        }
        return offspringFeatures;
    }
    
    private void move(){
        
        boolean moved = false;

        while(moved == false){     

            if(diet == 1 && this.potentialPrey.size() != 0)
            {
                for(int i = 0; i< this.potentialPrey.size();i++)
                {
                    setX(potentialPrey.get(i).getX());
                    setY(potentialPrey.get(i).getY());
                    
                    moved = true;
                    break;
                }
            }
            
            if(moved == false)
            {
            
                int fig = (int)(Math.random() * 4);
                switch(fig){
                    case 0:
                        if (x==0)
                        {
                            break;
                        }
                        if(copiedSquares[x-1][y].getTerrain() != 3 || isFlying == 1)
                        {
                            setX(x-1);
                            moved = true;
                            System.out.println("north.");
                            break;
                        }    
                    case 1:
                        if (x == (rows-1))
                        {
                            break;
                        }
                        if(copiedSquares[x+1][y].getTerrain() != 3 || isFlying == 1){
                            setX(x+1);
                            moved = true;
                            System.out.println("south.");
                            break;
                        }
                    case 2:
                        if (y == 0)
                        {
                            break;
                        }
                        if(copiedSquares[x][y-1].getTerrain() != 3 || isFlying == 1){
                            setY(y-1);
                            moved = true;
                            System.out.println("west.");
                            break;
                        }
                    case 3:
                        if (y == (columns-1))
                        {
                            break;    
                        }
                        if(copiedSquares[x][y+1].getTerrain() != 3 || isFlying == 1){
                            setY(y+1);
                            moved = true;
                            System.out.println("east.");
                            break;
                        }
                }
            }
        }  
    }
    
    private void determineAction(){
        
        System.out.println("I'm determining my next action based on the gathered data...");
        determineMate();
        
        if (anxIndex >= 80.0){
            
            System.out.println("I'm feeling very anxious and ");
            
            if(diet == 0){
                
                if(energyReserve < 6 && copiedSquares[x][y].getFood() > 0){
                    System.out.print("my energy is low so I'll eat some grass.");
                    herbivoreForaging();
                
                } else {       
                    System.out.print("I have plenty energy left or there's no food here, so I'll move ");
                    move();
                }
            }
            
            if(diet == 1){
                System.out.println("since I'm a predator I'll look for prey ");
                determinePrey();
                System.out.println(potentialPrey.size() + " potential prey found.");
            
                if(energyReserve >= 15){
                        System.out.print("but I've got enough energy so I'll just move ");
                        move();
                } else {
                    System.out.print("and because I'm low on energy I'll try to hunt.");            
                    carnivoreForaging();            

                    if (!foundPrey){
                            System.out.println("Nothing to hunt, so I'll move and look for prey in the");
                            move();
                            carnivoreForaging();
                    }    
                }
            }
        } else {                                                                //If the creature is not anxious to move
            System.out.println("I'm not feeling anxious at all.");
            
            if(diet == 0){
                System.out.println("Since I'm a herbivore, I'll just eat some grass.");//If herbivore
                herbivoreForaging();                                            //then eat
            } else {                                                            //if carnivore
                System.out.println("Since I'm a carnivore, I'll determine possible prey.");
                determinePrey();                                                //then check for potential prey in my square and neighbouring squares
               
                System.out.println(potentialPrey.size() + " potential prey found.");
                
                if(energyReserve < 60){
                    System.out.println("I'm low on energy, so I'll check it out.");
                    carnivoreForaging();

                    if (!foundPrey)
                    {
                        System.out.println("Since I couldn't hunt, I'll move and try to hunt there. Moved ");
                        move();
                        carnivoreForaging();
                        if (!foundPrey){
                            
                        }
                    }
                } else {
                    System.out.println("I'm feeling very fat, so I'll just chill.");
                }
            }
        }
        
        energyReserve = energyReserve - energyExpenditure;
        
        if (energyReserve <= 0){
            System.out.println("Ran out of energy, I'm dead!");
            copiedCreatures.remove(this);
        }
    }

    private void determinePrey(){
        
        if(x != 0)
        {   
            for(int i = 0; i < copiedSquares[x-1][y].getInhabitants().size(); i++){
                
                if (unfitPrey.size() > 0){
                    
                    for(int n = 0; n < unfitPrey.size(); n++){
                        
                        if(copiedSquares[x-1][y].getInhabitants().get(i).getId() != unfitPrey.get(n).getId()){
                            
                            potentialPrey.add(copiedSquares[x-1][y].getInhabitants().get(i));
                        }
                    }
                } else {
                    potentialPrey.add(copiedSquares[x-1][y].getInhabitants().get(i));
                }
            }
        }
        
        if(x != (rows-1))
        {
            for(int i = 0; i < copiedSquares[x+1][y].getInhabitants().size(); i++){
                
                if (unfitPrey.size() > 0){
                    
                    for(int n = 0; n < unfitPrey.size(); n++){
                        
                        if(copiedSquares[x+1][y].getInhabitants().get(i).getId() != unfitPrey.get(n).getId()){
                            
                            potentialPrey.add(copiedSquares[x+1][y].getInhabitants().get(i));
                        }
                    }
                } else {
                    potentialPrey.add(copiedSquares[x+1][y].getInhabitants().get(i));
                }
            }
        }
        
        if (y != 0)
        {
            for(int i = 0; i < copiedSquares[x][y-1].getInhabitants().size(); i++){
                
                if (unfitPrey.size() > 0){
                    
                    for(int n = 0; n < unfitPrey.size(); n++){
                        
                        if(copiedSquares[x][y-1].getInhabitants().get(i).getId() != unfitPrey.get(n).getId()){
                            
                            potentialPrey.add(copiedSquares[x][y-1].getInhabitants().get(i));
                        }
                    }
                } else {
                    potentialPrey.add(copiedSquares[x][y-1].getInhabitants().get(i));
                }
            }
        }
        
        if(y != (columns-1))
        {
            for(int i = 0; i < copiedSquares[x][y+1].getInhabitants().size(); i++){
                
                if (unfitPrey.size() > 0){
                    
                    for(int n = 0; n < unfitPrey.size(); n++){
                        
                        if(copiedSquares[x][y+1].getInhabitants().get(i).getId() != unfitPrey.get(n).getId()){
                            
                            potentialPrey.add(copiedSquares[x][y+1].getInhabitants().get(i));
                        }
                    }
                } else {
                    potentialPrey.add(copiedSquares[x][y+1].getInhabitants().get(i));
                }
            }
        }        
    }
    
    private void herbivoreForaging(){
        
        if(foodWhereIStand <= energyConsumption){
                energyReserve = energyReserve + foodWhereIStand;
                copiedSquares[x][y].setFood(0);
            }
            // jos on reilusti ruokaa, niin syödään ja kasvatetaan varastoja
        else {
            copiedSquares[x][y].setFood(foodWhereIStand - energyConsumption);
            energyReserve = energyReserve + energyConsumption;

            if(energyReserve >= energyReserveMax){   
                energyReserve = energyReserveMax;
            }
        }
    }

    private void carnivoreForaging(){
        
        for(int i = 0; i < inhabitants.size(); i++){

            if(inhabitants.get(i).getSize() <= size && inhabitants.get(i).getId() != id || inhabitants.get(i).getHasHerd() == 0 && hasHerd == 1 && inhabitants.get(i).getId() != id){

                foundPrey = true;
                System.out.println("Looks doable, I'll hunt him. His id is: " + inhabitants.get(i).getId());
                if(tag(inhabitants.get(i).getSurvivalFeatures(), this.getSurvivalFeatures())){
                    System.out.println("Nom nom, caught him. Got " + inhabitants.get(i).getCarcassEnergyValue() + " energy.");
                    energyReserve = energyReserve + inhabitants.get(i).getCarcassEnergyValue();
                    copiedCreatures.remove(inhabitants.get(i));
                    i = copiedSquares[x][y].getInhabitants().size();   
                } else { 
                    System.out.println("Didn't catch the bugger.");
                }
            } else {
                System.out.println("Can't hunt that, so I'll remember his id.");
                unfitPrey.add(this.inhabitants.get(i));
            }
        }
    }
        
    private boolean tag(int[]preyFeatures, int[]myFeatures){       
        
        // aliohjelma palauttaa kykyjen eroista lasketun kertoimen joka laitetaan math.randomiin
        double isCaught = Math.random() * (compareSurvivalFeatures(preyFeatures, myFeatures))+2-(copiedSquares[x][y].getShelter()/20);
        
        if (isCaught > 0){
            return true;
        } else {
            return false;
        }
    }
    
    private int compareSurvivalFeatures(int[]preyFeatures, int[]hunterFeatures){
        int compareIndex = 0;
        
        if(preyFeatures[0] < hunterFeatures[0]){
            compareIndex--;
        }
        if(preyFeatures[0] > hunterFeatures[0]){
            compareIndex++;
        }
        if(preyFeatures[1] < hunterFeatures[1]){
            compareIndex--;
        }
        if(preyFeatures[1] > hunterFeatures[1]){
            compareIndex++;
        }
        if(preyFeatures[2] < hunterFeatures[2]){
            compareIndex--;
        }
        if(preyFeatures[2] > hunterFeatures[2]){
            compareIndex++;
        }
        if(preyFeatures[3] < hunterFeatures[3]){
            compareIndex--;
        }
        if(preyFeatures[3] > hunterFeatures[3]){
            compareIndex++;
        }
        if(preyFeatures[4] < hunterFeatures[4]){
            compareIndex--;
        }
        if(preyFeatures[4] > hunterFeatures[4]){
            compareIndex++;
        }
        if(preyFeatures[5] < hunterFeatures[5]){
            compareIndex--;
        }
        if(preyFeatures[5] > hunterFeatures[5]){
            compareIndex++;
        }
        if(preyFeatures[6] < hunterFeatures[6]){
            compareIndex--;
        }
        if(preyFeatures[6] > hunterFeatures[6]){
            compareIndex++;
        }
        
        return compareIndex;
    }  
    
    public int[] getSurvivalFeatures(){
        int[] features = new int[7];
        
        features[0] = isFlying;
        features[1] = isBurrower;
        features[2] = hasFangs;
        features[3] = hasClaws;
        features[4] = hasTusks;
        features[5] = canProwl;
        features[6] = hasHerd;
        
        return features;        
    }
    
    public int getIsFlying(){
        return isFlying;
    }
    
    public int getCanProwl(){
        return canProwl;
    }
    
    public int getIsBurrower(){
        return isBurrower;
    }
    
    public int getHasFangs(){
        return hasFangs;
    }
    
    public int getHasClaws(){
        return hasClaws;
    }
    
    public int getHasTusks(){
        return hasTusks;
    }
    
    public int getReproductivity(){
        return reproductivity;
    }
    
    public int getTemperaturePreference(){
        return temperaturePreference;
    }
    
    public int getHasHerd() {
        return hasHerd;
    }

    public int getSize() {
        return size;
    }

    public int getId() {
        return id;
    }
    
    public boolean getHasBred(){
        return hasBred;
    }
    
    public int getInfertileCycles()
    {
        return infertileCycles;
    }
 
    public double getCarcassEnergyValue() {
        return carcassEnergyValue;
    }
    
    public ArrayList<Creature> getUnfitPrey() {
        return unfitPrey;
    }
    
    public int getDiet() {
        return diet;
    }
    
    private void setX(int x){
        this.x = x;
    }
    
    public int getX(){
        return x;
    }
    
    private void setY(int y){
        this.y = y;
    }
    
    public int getY(){
        return y;
    }
    
     public ArrayList<Creature> getCopiedCreatures(){
        return copiedCreatures;
    }
     
     public Square[][] getCopiedSquares(){
        return copiedSquares;
    }
    
}
