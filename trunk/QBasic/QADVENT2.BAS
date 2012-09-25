'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>
'           <<Press Shift+F5>>


' todo list:
'  fix playability problem.
'  add in map editor
'  remove non essential lines
'   LevelDefault
'   test stuff

DEFINT A-Z

CONST DIRECTORY$ = "C:\QADVENTU"
                             'Change this to suit your needs (no ending slash)
      

        'Version 0.8, Release 2


OPTION BASE 1

DECLARE SUB DoSaveGame ()
DECLARE SUB DisplaySavedGames ()
DECLARE SUB GetSavedGames () 'Find which save slots are used.
DECLARE SUB UnBlockExit ()
DECLARE SUB CLearScreen ()
DECLARE SUB DoHpUp ()
DECLARE SUB WaitForKey () 'Used instead of SLEEP because of a really wierd bug
          'in INKEY$ that caused the player to move large spaces after battles
DECLARE SUB GoRight ()
DECLARE SUB GoUp ()    'self explanatory
DECLARE SUB GoDown ()
DECLARE SUB GoLeft ()
DECLARE SUB StatusChange (Text$, colour) 'change the status bar
DECLARE SUB LoadGame ()
DECLARE SUB PlayCustom ()         'play a custom map
DECLARE SUB LineBorder (JointEnabled%) 'for drawing the screen
DECLARE SUB DoLevelUp ()          'advance to next level
DECLARE SUB DoWeaponUp ()         'increase weapon strength
DECLARE SUB DoEnemy ()            'battle an enemy
DECLARE SUB Init ()               'init game
DECLARE SUB DoShieldUp ()         'increase shield strength
DECLARE SUB ClearStatusBar ()     'erase status bar
DECLARE SUB LoadInternalMap (map%)          'load a map
DECLARE SUB LoadExternalMap (Location$)
DECLARE SUB SaveExternalMap (Location$, map%) 'save a map
DECLARE SUB PlayGame ()
DECLARE SUB StarBorder (colour%)
DECLARE SUB DisplayMap (map%)
DECLARE SUB Center (txt$, row%, clr%)

CONST BLANK = 0
CONST BLOCK = 1
CONST PLAYER = 2
CONST HpUp = 7
CONST WEAPONUP = 5   'Just so I don't have to remember them
CONST SHIELDUP = 4   'Also corresponds with the color of the object
CONST LEVELUP = 6    '(see SUB DisplayMap)
CONST Enemy = 3
CONST SaveGame = 8

CONST MAXMAP = 14
CONST MAXY = 16
CONST MAXX = 8
CONST DispMapOffX = 2
CONST DispMapOffY = 11

TYPE SaveGame
 Description AS STRING * 16
 Level AS INTEGER
 PlayerX AS INTEGER
 PlayerY AS INTEGER
 WeaponStrength AS INTEGER
 ShieldStrength AS INTEGER
 CurrentHP AS INTEGER
 EnemiesRemaining AS INTEGER
END TYPE

RANDOMIZE TIMER
DIM SHARED Level%(0 TO MAXMAP, MAXX, MAXY), Enemies%(0 TO MAXMAP)
DIM SHARED chars%(0 TO 8)
DIM SHARED Weapon AS INTEGER, Shield AS INTEGER, x AS INTEGER, y AS INTEGER, HP AS INTEGER
DIM SHARED map%, InBattle AS INTEGER
DIM SHARED ExitX AS INTEGER, ExitY AS INTEGER
DIM SHARED SaveGames(10) AS SaveGame, SaveGameExists(10) AS INTEGER
DIM SHARED I AS INTEGER, AttemptGetSavedGames AS INTEGER
DIM SHARED AttemptToMKDIR AS INTEGER, AttemptOPENCustomMap AS INTEGER

ON ERROR GOTO ErrHandler
AttemptToMKDIR = 1
 MKDIR DIRECTORY$           'comment if lines give an error
 MKDIR DIRECTORY$ + "\save"
AttemptToMKDIR = 0

Init

CLearScreen
StarBorder (INT(RND * 16) + 1)
Center "QBasic Adventure", 5, 6
Center "Made by Addison Babcock", 7, 5

DO
  K$ = INKEY$
LOOP UNTIL K$ <> ""
K$ = ""

MainMenu:
CLearScreen
StarBorder INT(RND * 16)
Center "What would you like to do?", 3, 5
LOCATE 5, 4
PRINT "1: Play Game!"
LOCATE 6, 4
PRINT "2: Load Saved Game!"
LOCATE 7, 4
PRINT "3: Play Custom Map!"
LOCATE 8, 4
PRINT "4: Enter map editor!"
LOCATE 9, 4
PRINT "5: Exit!"
WHILE A = 0
  K$ = INKEY$
  SELECT CASE K$
    CASE "1"
      LoadInternalMap 1
      DisplayMap 1
      PlayGame
      A = 1
    CASE "2"
      LoadGame
      A = 1
    CASE "3"
      PlayCustom
      A = 1
    CASE "4"
      'MakeMap
      'A = 1
    CASE "5"
      END
  END SELECT
WEND



'begin map data


Level1:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,4,1,3,5,1,0,0,7,0,0,0,0,0,2,1
DATA 1,3,1,3,3,1,0,0,0,0,0,0,3,0,0,1
DATA 1,3,1,7,1,1,3,0,0,0,0,0,0,0,0,1
DATA 1,7,0,0,0,0,0,0,0,3,0,0,0,0,0,1
DATA 1,0,0,3,0,0,7,0,0,0,0,0,0,3,0,1
DATA 1,8,0,0,0,0,0,0,0,0,0,0,0,0,0,1
DATA 1,1,1,6,1,1,1,1,1,1,1,1,1,1,1,1
Level2:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,7,2,7,0,0,0,3,0,0,0,0,0,0,1
DATA 1,0,1,7,1,0,0,0,1,0,1,0,1,0,0,1
DATA 6,0,0,0,0,0,0,1,1,5,0,0,0,1,1,1
DATA 1,0,4,0,1,3,0,1,0,0,0,1,3,3,7,1
DATA 1,0,1,0,0,0,0,0,4,0,0,1,3,7,0,1
DATA 1,0,0,0,0,0,0,0,1,0,0,1,3,0,8,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level3:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,8,7,0,0,0,0,0,0,0,0,0,0,0,3,1
DATA 6,0,7,0,1,3,0,0,0,0,0,1,4,1,5,1
DATA 1,0,0,7,0,3,0,1,3,0,0,1,3,1,2,1
DATA 1,0,3,0,0,1,0,0,0,0,0,1,7,1,5,1
DATA 1,0,0,1,0,0,0,0,1,0,0,1,1,1,1,1
DATA 1,0,0,0,4,0,0,0,3,0,0,0,7,5,3,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level4:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,0,3,0,0,0,3,0,0,0,3,0,0,0,1
DATA 1,0,1,4,1,1,1,1,1,1,1,1,1,1,0,6
DATA 1,0,1,3,0,3,0,1,0,3,0,1,8,1,0,1
DATA 1,3,1,1,0,1,0,3,0,1,0,5,3,1,0,1
DATA 1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,1
DATA 1,0,0,7,7,0,2,0,7,7,0,0,0,0,3,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level5:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,7,1,0,4,0,1,0,0,0,1,0,0,0,0,1
DATA 1,2,1,0,1,0,1,0,1,0,1,0,1,0,0,1
DATA 1,7,1,3,1,0,1,5,1,3,1,3,1,7,0,6
DATA 1,0,1,7,1,3,1,3,1,0,1,0,1,7,0,1
DATA 1,3,1,0,1,7,1,0,1,7,1,0,1,7,0,1
DATA 1,0,0,0,1,0,0,0,1,0,0,0,1,0,8,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level6:
DATA 1,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1
DATA 1,0,0,0,3,0,0,4,0,0,0,0,0,0,0,1
DATA 1,7,1,1,3,1,1,0,1,1,0,1,1,0,0,1
DATA 1,2,7,0,0,3,0,0,0,0,0,0,0,0,0,1
DATA 1,7,0,1,1,3,1,1,0,1,1,0,1,1,0,1
DATA 1,0,0,0,3,0,0,5,0,0,0,0,0,3,3,1
DATA 1,0,0,0,3,0,0,0,0,0,0,0,0,3,8,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level7:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,0,0,0,0,0,0,0,0,0,4,0,0,0,1
DATA 1,0,1,1,1,0,1,7,1,1,1,1,1,1,0,1
DATA 1,0,1,3,3,0,1,7,3,5,3,7,3,1,0,1
DATA 1,0,1,8,1,0,1,1,3,1,7,3,1,1,0,1
DATA 1,0,1,1,1,0,1,1,1,1,1,1,1,1,7,1
DATA 1,0,0,0,0,7,0,0,2,0,0,0,0,0,7,6
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level8:
DATA 1,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1
DATA 1,7,0,0,0,0,0,0,8,0,0,0,0,0,7,1
DATA 1,0,3,3,1,3,3,1,3,3,1,3,3,1,0,1
DATA 1,0,1,1,0,1,1,0,1,1,0,1,1,3,0,1
DATA 1,0,1,1,0,1,1,0,1,1,0,1,1,3,0,1
DATA 1,7,0,3,1,3,3,1,3,3,1,3,3,1,0,1
DATA 1,2,7,0,0,0,0,4,5,0,0,0,0,0,7,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level9:
DATA 1,1,1,1,1,1,1,1,1,6,1,1,1,1,1,1
DATA 1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,1
DATA 1,7,0,0,3,3,3,3,3,3,3,3,3,3,0,1
DATA 1,7,0,0,3,7,7,7,7,7,7,7,7,3,0,1
DATA 1,7,0,0,3,7,0,0,0,0,0,0,7,3,0,1
DATA 1,7,0,0,3,7,3,5,3,4,7,3,7,3,0,1
DATA 1,7,0,0,3,7,3,7,2,3,7,3,7,3,0,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level10:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,7,7,7,7,7,7,3,3,7,7,7,7,7,7,1
DATA 1,7,7,7,7,7,7,3,3,7,7,7,7,7,7,1
DATA 1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1
DATA 1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1
DATA 1,0,0,0,0,0,0,3,3,0,0,0,0,0,0,1
DATA 1,5,0,0,0,0,0,3,3,2,0,0,0,0,4,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level11:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1
DATA 1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,1
DATA 1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,1
DATA 1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,1
DATA 1,7,1,7,1,7,1,7,1,7,1,7,1,7,8,1
DATA 1,2,1,4,1,5,1,0,1,0,1,0,1,7,7,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,1
Level12:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,7,3,0,0,3,7,7,3,0,0,3,7,7,2,1
DATA 1,7,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,3,0,0,3,7,7,3,0,0,3,7,7,3,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1
DATA 1,8,0,0,3,1,0,0,3,1,0,0,3,1,0,1
DATA 6,0,3,1,7,7,3,1,7,7,3,1,7,7,3,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level13:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,1
DATA 1,0,0,3,0,0,0,7,0,0,0,3,0,1,0,1
DATA 1,0,1,1,1,1,1,1,1,1,1,1,0,1,3,1
DATA 1,7,1,4,7,0,8,0,0,0,0,0,0,1,0,1
DATA 1,0,1,5,7,0,0,0,0,0,0,0,7,0,0,1
DATA 1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,3,0,0,0,7,0,0,0,3,0,0,0,2,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
Level14:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,3,7,7,7,7,3,3,7,7,0,0,0,0,3,1
DATA 1,7,1,3,3,1,1,1,1,3,1,1,1,1,7,1
DATA 1,7,1,7,7,1,7,7,1,3,1,4,5,1,7,1
DATA 1,7,1,1,1,1,7,7,1,7,1,4,5,1,7,1
DATA 1,7,1,3,3,7,3,3,1,1,1,3,3,1,7,1
DATA 1,3,0,7,3,3,7,3,3,7,3,3,7,1,2,1
DATA 1,1,8,1,1,1,1,1,1,1,1,1,6,1,1,1

LevelDefault:
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 'For copy/paste purposes
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 'erase when published
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1
DATA 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1
DATA 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1

CharData:
DATA 0,42,2,1,158,157,88,43,36
'Default character set to use, in ASCII codes

ErrHandler:
ErrorNumber = ERR
IF AttemptToMKDIR = 1 THEN
 RESUME NEXT
END IF

IF AttemptGetSavedGames = 1 THEN
 SaveGameExists(I) = 0
 RESUME NEXT
END IF

IF AttemptOPENCustomMap = 1 THEN
 PRINT "Not found!"
 WaitForKey
 GOTO MainMenu
END IF

IF ErrorNumber = 255 THEN
 SCREEN 12
 CLearScreen
 PRINT "A map error has occured"
 PRINT "The map you were using may be invalid"
 PRINT "Please email corkhead0@hotmail.com"
 SYSTEM
END IF

CLearScreen
SCREEN 12
PRINT "An error type"; ErrorNumber; "has occured"
PRINT "Please email corkhead0@hotmail.com"
PRINT "Be sure to include the following:"
PRINT "-The above error code"
PRINT "-A copy of this game (it might have been corrupted)"
PRINT "-What you were doing at the time the error occured."
SYSTEM

DEFINT A-Z
SUB Center (txt$, row%, clr%)

COLOR clr%
LOCATE row%, 20 - INT((LEN(txt$) / 2))
PRINT txt$

END SUB

DEFINT A-Z
SUB CLearScreen

temp$ = SPACE$(40)
FOR x = 1 TO 25
 LOCATE x, 1
 PRINT temp$
NEXT
LOCATE 1, 1

END SUB

DEFINT A-Z
SUB ClearStatusBar


FOR I = 14 TO 22
  LOCATE I, 2
  PRINT SPACE$(37)
NEXT I
 
END SUB

SUB DisplayMap (map%)

CLearScreen
BorderType = INT(RND * 2) + 1
COLOR map%
SELECT CASE BorderType
  CASE 1: StarBorder (map% + 1)
  CASE 2: LineBorder (1)
END SELECT

FOR TempX = 2 TO 39
  LOCATE 12, TempX
  PRINT CHR$(205)
NEXT TempX

FOR TempX = 1 TO MAXX
  FOR TempY = 1 TO MAXY
    SELECT CASE Level%(map%, TempX, TempY)
      CASE 0
      CASE 1
      CASE 2
                                   'Determine the type of tile...
        x = TempX
        y = TempY
      CASE 3
      CASE 4
      CASE 5
      CASE 6
        ExitX = TempX
        ExitY = TempY
      CASE 7                       'Do any special handling
      CASE 8
      CASE ELSE
        CLearScreen
        Center "Error: Attempted to load bad map, " + STR$(map%), 4, 15
        END
    END SELECT
    COLOR Level%(map%, TempX, TempY)
    LOCATE TempX + 2, TempY + 11   '...and then display it.
    PRINT CHR$(chars%(Level%(map%, TempX, TempY)))
  NEXT TempY
NEXT TempX
SELECT CASE map%
CASE 0
 Stats$ = " custom"
CASE ELSE
 Stats$ = STR$(map%)
END SELECT

StatusChange "", 0
StatusChange "Level" + Stats$, 1
StatusChange "", 0

END SUB

DEFINT A-Z
SUB DisplaySavedGames

CLearScreen
FOR I = 1 TO 10
 PRINT I;
 IF I = 10 THEN
  PRINT ") ";
 ELSE
  PRINT " ) ";
 END IF
 IF SaveGameExists(I) = 1 THEN
  PRINT SaveGames(I).Description
 ELSE
  PRINT "No saved game exists in this slot"
 END IF
NEXT I
PRINT

END SUB

SUB DoEnemy

StatusChange "You encountered an enemy!", 4
EnemyHP = 2.333 * map%
EWeapon = 4 + map% * 2
EShield = 4 + map% * 2
Attacker = INT(RND * 2)
WaitForKey
IF Attacker = 1 THEN
 StatusChange "You will attack first!", 2
ELSE
 StatusChange "The enemy will attack first!", 4
END IF
WaitForKey

DO
 IF Attacker = 1 THEN
  Damage = INT(RND * Weapon) + 3
  Defense = INT(RND * EShield)
  IF Defense >= Damage THEN
   StatusChange "You missed.", 4
   WaitForKey
  ELSE
   FactoredDamage = Damage - Defense
   EnemyHP = EnemyHP - FactoredDamage
   StatusChange "You did" + STR$(FactoredDamage) + " damage.", 2
   WaitForKey
   StatusChange "The enemy now has" + STR$(EnemyHP) + " HP.", 2
   WaitForKey
  END IF
  Attacker = 0
 ELSE
  Damage = INT(RND * EWeapon) + 1
  Defense = INT(RND * Shield) + 1
  IF Defense >= Damage THEN
   StatusChange "The enemy missed.", 2
   WaitForKey
  ELSE
   IF INT(RND * 2) = 0 THEN
    FactoredDamage = Damage - Defense
    HP = HP - FactoredDamage
    StatusChange "You received" + STR$(FactoredDamage) + " damage.", 4
    WaitForKey
    StatusChange "You now have" + STR$(HP) + " HP.", 4
    WaitForKey
   ELSE
    StatusChange "The enemy missed.", 2
    WaitForKey
   END IF
  END IF
  Attacker = 1
 END IF
LOOP UNTIL EnemyHP <= 0 OR HP <= 0

IF HP <= 0 THEN
 StatusChange "You have been defeated.", 4
 WaitForKey
 END
ELSE
 StatusChange "You have defeated the enemy!", 2
 WaitForKey
 Enemies%(map%) = Enemies%(map%) - 1
 IF Enemies%(map%) = 0 THEN
  UnBlockExit
 END IF
END IF

END SUB

SUB DoHpUp

HpPlus = INT(RND * (map% * 3)) + 2
StatusChange "You gained" + STR$(HpPlus) + "HP.", 2
HP = HP + HpPlus
StatusChange "Your HP is now" + STR$(HP), 2

END SUB

DEFINT A-Z
SUB DoLevelUp

IF Enemies%(map%) > 0 THEN
   StatusChange "Try killing all the enemies first!", 4
ELSE
   map% = map% + 1
   LoadInternalMap map%
   DisplayMap map%
END IF

END SUB

DEFINT A-Z
SUB DoSaveGame

DisplaySavedGames

GetInput:
INPUT "Save to which game slot"; UseSlot
IF UseSlot > 10 OR UseSlot < 1 THEN
 PRINT "Invalid. Try again"
 GOTO GetInput
END IF

SaveGameExists(UseSlot) = 1
OPEN DIRECTORY$ + "\save\SAVE" + STR$(UseSlot) + ".SAV" FOR OUTPUT AS #1
INPUT "Enter a game description"; SaveGames(UseSlot).Description
SaveGames(UseSlot).Level = map%
SaveGames(UseSlot).PlayerX = x
SaveGames(UseSlot).PlayerY = y
SaveGames(UseSlot).WeaponStrength = Weapon
SaveGames(UseSlot).ShieldStrength = Shield
SaveGames(UseSlot).CurrentHP = HP
SaveGames(UseSlot).EnemiesRemaining = Enemies%(map%)
PRINT #1, SaveGames(UseSlot).Description
PRINT #1, SaveGames(UseSlot).Level
PRINT #1, SaveGames(UseSlot).PlayerX
PRINT #1, SaveGames(UseSlot).PlayerY
PRINT #1, SaveGames(UseSlot).WeaponStrength
PRINT #1, SaveGames(UseSlot).ShieldStrength
PRINT #1, SaveGames(UseSlot).CurrentHP
PRINT #1, SaveGames(UseSlot).EnemiesRemaining
FOR TempX = 1 TO MAXX
 FOR TempY = 1 TO MAXY
  PRINT #1, Level%(map%, TempX, TempY)  'if the abiblity to backtrack through
 NEXT                                  'levels is added, I will need to save
NEXT                                   'them too

CLOSE #1
StatusChange "Game succesfully saved.", 7
WaitForKey

END SUB

DEFINT A-Z
SUB DoShieldUp

StatusChange "You found a better shield!", 2
Shield = Shield + INT(RND * 2) + 1

END SUB

SUB DoWeaponUp

StatusChange "You found a better weapon!", 2
Weapon = Weapon + INT(RND * 2) + 1

END SUB

DEFINT A-Z
SUB GetSavedGames

ON ERROR GOTO ErrHandler

AttemptGetSavedGames = 1
FOR I = 1 TO 10
 SaveGameExists(I) = 1
 OPEN DIRECTORY$ + "\save\SAVE" + STR$(I) + ".SAV" FOR INPUT AS #1
 IF SaveGameExists(I) = 1 THEN
  INPUT #1, SaveGames(I).Description
  CLOSE #1
 END IF
NEXT I
AttemptGetSavedGames = 0

END SUB

DEFINT A-Z
SUB GoDown

newX = x + 1
newY = y
COLOR 2
SELECT CASE Level%(map%, newX, newY)
 CASE 0
  GOSUB MoveDown
 CASE 1
 CASE 2
  ERROR 255
 CASE 3
  DoEnemy
  GOSUB MoveDown
 CASE 4
  DoShieldUp
  GOSUB MoveDown
 CASE 5
  DoWeaponUp
  GOSUB MoveDown
 CASE 6
  DoLevelUp
 CASE 7
  DoHpUp
  GOSUB MoveDown
 CASE 8
  DoSaveGame
  DisplayMap map%
  WaitForKey
 CASE ELSE
  PRINT "Using bad map."
  PRINT "Program will end."
  END
END SELECT
EXIT SUB


MoveDown:
COLOR 2
Level%(map%, x, y) = 0
Level%(map%, newX, newY) = 2
LOCATE x + 2, y + 11
PRINT " "
LOCATE newX + 2, newY + 11
PRINT CHR$(chars%(2))
x = newX
y = newY
RETURN

END SUB

SUB GoLeft

newX = x
newY = y - 1
SELECT CASE Level%(map%, newX, newY)
 CASE 0
  GOSUB MoveLeft
 CASE 1
 CASE 2
  ERROR 255
 CASE 3
  DoEnemy
  GOSUB MoveLeft
 CASE 4
  GOSUB MoveLeft
  DoShieldUp
 CASE 5
  GOSUB MoveLeft
  DoWeaponUp
 CASE 6
  DoLevelUp
 CASE 7
  GOSUB MoveLeft
  DoHpUp
 CASE 8
  DoSaveGame
  DisplayMap map%
  WaitForKey
END SELECT
EXIT SUB

MoveLeft:
COLOR 2
Level%(map%, x, y) = 0
Level%(map%, newX, newY) = 2
LOCATE x + 2, y + 11
PRINT " "
LOCATE newX + 2, newY + 11
PRINT CHR$(chars%(2))
x = newX
y = newY
RETURN

END SUB

SUB GoRight

newX = x
newY = y + 1
SELECT CASE Level%(map%, newX, newY)
 CASE 0
  GOSUB MoveRight
 CASE 1
 CASE 2
  ERROR 255
 CASE 3
  DoEnemy
  GOSUB MoveRight
 CASE 4
  DoShieldUp
  GOSUB MoveRight
 CASE 5
  DoWeaponUp
  GOSUB MoveRight
 CASE 6
  DoLevelUp
 CASE 7
  DoHpUp
  GOSUB MoveRight
 CASE 8
  DoSaveGame
  DisplayMap map%
  WaitForKey
END SELECT
EXIT SUB


MoveRight:
COLOR 2
Level%(map%, x, y) = 0
Level%(map%, newX, newY) = 2
LOCATE x + 2, y + 11
PRINT " "
LOCATE newX + 2, newY + 11
PRINT CHR$(chars%(2))
x = newX
y = newY
RETURN

END SUB

SUB GoUp

newX = x - 1
newY = y
SELECT CASE Level%(map%, newX, newY)
 CASE 0
  GOSUB MoveUp
 CASE 1
 CASE 2
  ERROR 255
 CASE 3
  DoEnemy
  GOSUB MoveUp
 CASE 4
  DoShieldUp
  GOSUB MoveUp
 CASE 5
  DoWeaponUp
  GOSUB MoveUp
 CASE 6
  DoLevelUp
  GOSUB MoveUp
 CASE 7
  DoHpUp
  GOSUB MoveUp
 CASE 8
  DoSaveGame
  DisplayMap map%
  WaitForKey
END SELECT
EXIT SUB

MoveUp:
COLOR 2
Level%(map%, x, y) = 0
Level%(map%, newX, newY) = 2
LOCATE x + 2, y + 11
PRINT " "
LOCATE newX + 2, newY + 11
PRINT CHR$(chars%(2))
x = newX
y = newY
RETURN

END SUB

DEFINT A-Z
SUB Init

HP = 10
map% = 1
Weapon = 3
Shield = 4

RESTORE CharData
FOR I = 0 TO 8
  READ chars(I)
NEXT I

GetSavedGames

CLearScreen
SCREEN 13

END SUB

DEFINT A-Z
SUB LineBorder (JointEnabled%)


LOCATE 1, 1
PRINT CHR$(201)
LOCATE 1, 40
PRINT CHR$(187)
LOCATE 23, 1
PRINT CHR$(200)
LOCATE 23, 40
PRINT CHR$(188)
FOR x = 2 TO 39
  LOCATE 1, x
  PRINT CHR$(205)
  LOCATE 23, x
  PRINT CHR$(205)
NEXT x
FOR y = 2 TO 22
  LOCATE y, 1
  PRINT CHR$(186)
  LOCATE y, 40
  PRINT CHR$(186)
NEXT y
IF JointEnabled% = 1 THEN
  LOCATE 12, 1
  PRINT CHR$(204)
  LOCATE 12, 40
  PRINT CHR$(185)
  FOR x = 2 TO 39
    LOCATE 12, x
    PRINT CHR$(205)
  NEXT
END IF

END SUB

SUB LoadExternalMap (Location$)

OPEN Location$ FOR INPUT AS #1
FOR TempX = 1 TO MAXX
  FOR TempY = 1 TO MAXY
    INPUT #1, Level%(0, TempX, TempY)
  NEXT TempY
NEXT TempX
FOR I = 0 TO 8
   INPUT #1, chars%(I)
NEXT I
CLOSE #1
DisplayMap 0

END SUB

SUB LoadGame

DisplaySavedGames

LoadGameGetInput:
INPUT "Load game from which slot"; UseSlot
IF UseSlot > 10 OR UseSlot < 1 THEN
 PRINT "Invalid slot. Try again"
 GOTO LoadGameGetInput
ELSE
 IF SaveGameExists(UseSlot) = 0 THEN
  PRINT "No game exists in this slot."
  PRINT "Select a different slot."
  GOTO LoadGameGetInput
 END IF
END IF

OPEN DIRECTORY$ + "\save\SAVE" + STR$(UseSlot) + ".SAV" FOR INPUT AS #1
INPUT #1, Garbage$            'Description of game is already known
INPUT #1, SaveGames(UseSlot).Level
INPUT #1, SaveGames(UseSlot).PlayerX
INPUT #1, SaveGames(UseSlot).PlayerY
INPUT #1, SaveGames(UseSlot).WeaponStrength 'Update in game records
INPUT #1, SaveGames(UseSlot).ShieldStrength
INPUT #1, SaveGames(UseSlot).CurrentHP
INPUT #1, SaveGames(UseSlot).EnemiesRemaining
IF SaveGames(UseSlot).Level <> 0 THEN
 FOR TempX = 1 TO MAXX
  FOR TempY = 1 TO MAXY
   INPUT #1, Level%(SaveGames(UseSlot).Level, TempX, TempY)
  NEXT
 NEXT
END IF
CLOSE #1

map% = SaveGames(UseSlot).Level
x = SaveGames(UseSlot).PlayerX
y = SaveGames(UseSlot).PlayerY
Weapon = SaveGames(UseSlot).WeaponStrength 'Initialize variables
Shield = SaveGames(UseSlot).ShieldStrength
HP = SaveGames(UseSlot).CurrentHP
Enemies%(map%) = SaveGames(UseSlot).EnemiesRemaining

DisplayMap (map%)                          'And show the results
StatusChange "Game loaded succesfully.", 7
PlayGame

END SUB

SUB LoadInternalMap (map%)

SELECT CASE map%
  CASE 1: RESTORE Level1
  CASE 2: RESTORE Level2
  CASE 3: RESTORE Level3
  CASE 4: RESTORE Level4
  CASE 5: RESTORE Level5
  CASE 6: RESTORE Level6   'Restore the appropriate level map
  CASE 7: RESTORE Level7
  CASE 8: RESTORE Level8
  CASE 9: RESTORE Level9
  CASE 10: RESTORE Level10
  CASE 11: RESTORE Level11
  CASE 12: RESTORE Level12
  CASE 13: RESTORE Level13
  CASE 14: RESTORE Level14
END SELECT
FOR TempY = 1 TO 8
  FOR TempX = 1 TO 16
    READ Level%(map%, TempY, TempX)
    IF Level%(map%, TempY, TempX) = 3 THEN
      Enemies%(map%) = Enemies%(map%) + 1
    END IF
  NEXT TempX
NEXT TempY

END SUB

SUB PlayCustom

CLearScreen
LOCATE 1, 1
COLOR 15
INPUT "Where is the map located?", Location$
Location$ = UCASE$(RTRIM$(LTRIM$(Location$)))
AttemptOPENCustomMap = 1
LoadExternalMap Location$
AttemptOPENCustomMap = 0

END SUB

SUB PlayGame


WHILE 1 = 1
  key$ = INKEY$
    SELECT CASE key$
      CASE CHR$(0) + "K"
        GoLeft
      CASE CHR$(0) + "H"
        GoUp
      CASE CHR$(0) + "M"
        GoRight
      CASE CHR$(0) + "P"
        GoDown
    END SELECT
WEND

END SUB

SUB SaveExternalMap (Location$, map%)

OPEN Location$ FOR OUTPUT AS #1
FOR TempX = 1 TO 8                     'Output map data
  FOR TempY = 1 TO 16
    PRINT #1, Level%(map%, TempX, TempY)
  NEXT TempY
NEXT TempX
FOR I = 0 TO 8                         'Output character data
   PRINT #1, chars%(I)
NEXT I
CLOSE #1

END SUB

SUB StarBorder (colour%)


COLOR colour%
FOR TempX = 1 TO 40
  LOCATE 1, TempX
  PRINT "*"      'Display the border
  LOCATE 23, TempX
  PRINT "*"
NEXT TempX
FOR TempY = 2 TO 22
  LOCATE TempY, 1
  PRINT "*"
  LOCATE TempY, 40
  PRINT "*"
NEXT TempY

END SUB

DEFINT A-Z
SUB StatusChange (Text$, colour) STATIC

DIM StatBar(1 TO 8) AS STRING * 37
DIM StatClr(1 TO 8) AS INTEGER

Text$ = Text$ + SPACE$(37 - LEN(Text$))

FOR I = 1 TO 7
 StatBar(I) = StatBar(I + 1)
 StatClr(I) = StatClr(I + 1)
NEXT I

StatBar(8) = Text$
StatClr(8) = colour

FOR I = 14 TO 21
 LOCATE I, 2
 COLOR StatClr(I - 13)
 PRINT StatBar(I - 13)
NEXT I

END SUB

SUB UnBlockExit

LOCATE ExitX + DispMapOffX, ExitY + DispMapOffY
COLOR BLANK
PRINT CHR$(chars%(BLANK))

END SUB

SUB WaitForKey

key$ = INKEY$
WHILE key$ = ""
 key$ = INKEY$
WEND

END SUB

