# Startup Slam v2.0 - Smashteroids

This is the base project for the TinyMob Techniques for Prototyping Game AI workshop for [Startup Slam v2.0](http://www.startupslam.io/).


## Getting Started Guide

The main scene for Smashteroids is Game.unity. The main game managers are all
singletons so they can be easily accessed within the scene. The important
managers for this workshop are Tweakables and EnemyManager.

### Tweakables


This manager contains data about very game objects that can easily be tweaked.
The goal of this manager is to provide one place to change values while testing
and tweaking how game objects behave. For this workshop we've added tweakable
base stats for the player ship and enemy ships.

### EnemyShipManager


This manager controls how enemy ships spawn. It is setup to spawn ships in 
continuous waves. The base values are controlled by public variables for
wave frequency, the minimum time to wait between spawning new waves and
what enemy ships to spawn.

If you look in EnemyShipManager.cs at the coroutine "BeginEnemyWaves" you
will see that it spawns a new wave of enemies every time the player either
destroys the previous wave or the minimum wave time has elapsed. Currently
it calls SpawnSimpleNormalEnemyWave() to simply spawn one dumb enemy ship
in every wave. But if you comment that out and replace it with 
SpawnNewNormalEnemyWave() it will progressively spawn a random selection 
of enemy ship types for each wave.

Play around with the values and code in here to change how enemy ships spawn.


## Enemy Ship AI


Each enemy ship is constructed as a Prefab. Each of these has an EnemyShip.cs
component and an implementation of EnemyShipBaseAI.cs component.

### EnemyShip.cs


EnemyShip.cs controls one Enemy Ship. It keeps track of how much damage the 
ship receives, what it collides with, and it determines when the ship dies. It 
also calls the ship's AI brain once per frame.

### EnemyShipBaseAI.cs


EnemyShipBaseAI.cs is an abstract class that controls how an enemy ship behaves.
As an abstract class it has some virtual functions that can be overridden if
necessary, and it also has some abstract functions that must be implemented.

The main Bain() loop first does a Think(), then a Move() and finally a Shoot()
function call. This basic structure controls how the enemy ship will behave.

Play around with different values and implementations of this base class to
change how enemies act in the game.