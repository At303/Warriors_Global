* Check List
  1) Unity-Pro or Unity-5 is required for using this engine.
  
  2) Engine Initialization.
     a) DevEngine.Instance.LoadPackages([package list]); // "Devwinsoft/CharacterEngine/Prefab/Pak/".
     b) Instantiate([prefab]); // "Devwinsoft/CharacterEngine/Prefab/DevEngine(preset).prefab".

  3) Sprite Order Management
     You can manage order-value by using "DevwinCharacter::SetOrder()" method.
     The real order-value is [DevwinCharacter::Info->order] * 100 + [parts_order].
     If you do not manage order-value, draw-call can grow up.

  4) This engine uses "Layer 31" for make a character texture.
     If you use "Layer 31" in your project already, please change this value.
     This value is "DevEngine::layer_devwin_render_texture".

* Testing
  1) With using scrypt.
    A) Initializing.
      (case-1) Starts with using test-scene.
       Open test-scene. (Location="Devwinsoft/CharacterEngine/Test/DemoTest.unity")

      (case-2) Starts with empty scene.
       Instantiate engine. (Prefab-Location="Devwinsoft/CharacterEngine/Prefab/DevEngine(preset).prefab")
       Instantiate character. (Prefab-Location="Devwinsoft/CharacterEngine/Prefab/DevCharacter.prefab")
       And, attach testing scrypt. (Location="Devwinsoft/CharacterEngine/Test/TestCharacter.cs")
       And, assign TestCharacter::character to this game-object.

    B) Set-up character.
      Please check codes in TestCharacter::Start().
      Set different values and run.