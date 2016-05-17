using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using gamedata;

public class unity_IAP : MonoBehaviour,IStoreListener
 {
 private static IStoreController m_StoreController;                                                                  // Reference to the Purchasing system.
        private static IExtensionProvider m_StoreExtensionProvider;                                                         // Reference to store-specific Purchasing subsystems.
        
        // Product identifiers for all products capable of being purchased: "convenience" general identifiers for use with Purchasing, and their store-specific identifier counterparts 
        // for use with and outside of Unity Purchasing. Define store-specific identifiers also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

        private static string kProductID1000won =  "getmstone_1000won_2nd";                                                   // General handle for the subscription product.
        private static string kProductID2000won =  "getmstone_2000won_2nd";                                                   // General handle for the subscription product.
        private static string kProductID10000won =  "gemstone_10000won";                                                   // General handle for the subscription product.
        private static string kProductID20000won =  "gemstone_20000won";                                                   // General handle for the subscription product.

        private static string kProductNameAppleConsumable =    "com.unity3d.test.services.purchasing.consumable";             // Apple App Store identifier for the consumable product.
        private static string kProductNameAppleNonConsumable = "com.unity3d.test.services.purchasing.nonconsumable";      // Apple App Store identifier for the non-consumable product.
        private static string kProductNameAppleSubscription =  "com.unity3d.test.services.purchasing.subscription";       // Apple App Store identifier for the subscription product.

        private static string kProductNameGooglePlayInAppPurchase01 =  "getmstone_1000won_2nd";  // Google Play Store identifier for the subscription product.
        private static string kProductNameGooglePlayInAppPurchase02 =  "getmstone_2000won_2nd";  // Google Play Store identifier for the subscription product.
        private static string kProductNameGooglePlayInAppPurchase03 =  "gemstone_10000won";  // Google Play Store identifier for the subscription product.
        private static string kProductNameGooglePlayInAppPurchase04 =  "gemstone_2000won";  // Google Play Store identifier for the subscription product.

        void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (m_StoreController == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            }
        }
        
        public void InitializePurchasing() 
        {

            // If we have already connected to Purchasing ...
            if (IsInitialized())
            {

                // ... we are done here.
                return;
            }
            
            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            
            // Add a product to sell / restore by way of its identifier, associating the general identifier with its store-specific identifiers.
            //builder.AddProduct(kProductIDConsumable, ProductType.Consumable, new IDs(){{ kProductNameAppleConsumable,       AppleAppStore.Name },{ kProductNameGooglePlayConsumable,  GooglePlay.Name },});// Continue adding the non-consumable product.
            //builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable, new IDs(){{ kProductNameAppleNonConsumable,       AppleAppStore.Name },{ kProductNameGooglePlayNonConsumable,  GooglePlay.Name },});// And finish adding the subscription product.
            //builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){{ kProductNameAppleSubscription,       AppleAppStore.Name },{ kProductNameGooglePlaySubscription,  GooglePlay.Name },});// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
            builder.AddProduct(kProductID1000won, ProductType.Consumable, new IDs(){{ kProductNameGooglePlayInAppPurchase01,  GooglePlay.Name }});// Continue adding the non-consumable product.
            builder.AddProduct(kProductID2000won, ProductType.Consumable, new IDs(){{ kProductNameGooglePlayInAppPurchase02,  GooglePlay.Name }});// Continue adding the non-consumable product.
            builder.AddProduct(kProductID10000won, ProductType.Consumable, new IDs(){{ kProductNameGooglePlayInAppPurchase03,  GooglePlay.Name }});// Continue adding the non-consumable product.
            builder.AddProduct(kProductID20000won, ProductType.Consumable, new IDs(){{ kProductNameGooglePlayInAppPurchase04,  GooglePlay.Name }});// Continue adding the non-consumable product.

            //builder.AddProduct(kProductID2000won, ProductType.Consumable, new IDs(){{ kProductNameGooglePlayInAppPurchase02,  GooglePlay.Name }});// Continue adding the non-consumable product.


            UnityPurchasing.Initialize(this, builder);
        }
        
        
        private bool IsInitialized()
        {
            // Only say we are initialized if both the Purchasing references are set.
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }
        
                
        
        public void BuySubscription()
        {
            // Buy the subscription product using its the general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            //BuyProductID(in_app_purchase_1);
        }
        
        public void Buy1000won()
        {
            // Buy the subscription product using its the general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductID1000won);
            
            // close InAppPurchase Window
            GameObject.Find("store_popup_window").SetActive(false);
        }
         public void Buy2000won()
        {
            // Buy the subscription product using its the general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductID2000won);
            
            // close InAppPurchase Window
            GameObject.Find("store_popup_window").SetActive(false);
        }
         public void Buy10000won()
        {
            // Buy the subscription product using its the general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductID10000won);
            
            // close InAppPurchase Window
            GameObject.Find("store_popup_window").SetActive(false);
        }
         public void Buy20000won()
        {
            // Buy the subscription product using its the general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductID20000won);
            
            // close InAppPurchase Window
            GameObject.Find("store_popup_window").SetActive(false);
        }
        void BuyProductID(string productId)
        {
            // If the stores throw an unexpected exception, use try..catch to protect my logic here.
            try
            {
                // If Purchasing has been initialized ...
                if (IsInitialized())
                {
                    // ... look up the Product reference with the general product identifier and the Purchasing system's products collection.
                    Product product = m_StoreController.products.WithID(productId);
                    
                    // If the look up found a product for this device's store and that product is ready to be sold ... 
                    if (product != null && product.availableToPurchase)
                    {
                        //NGUIDebug.Log  (string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
                        m_StoreController.InitiatePurchase(product);
                    }
                    // Otherwise ...
                    else
                    {
                        // ... report the product look-up failure situation  
                        //NGUIDebug.Log  ("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                    }
                }
                // Otherwise ...
                else
                {
                    // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
                    ////NGUIDebug.Log ("BuyProductID FAIL. Not initialized.");
                }
            }
            // Complete the unexpected exception handling ...
            catch (Exception e)
            {
                // ... by reporting any unexpected exception for later diagnosis.
                //NGUIDebug.Log  ("BuyProductID: FAIL. Exception during purchase. " + e);
            }
        }
        
        
        // Restore purchases previously made by this customer. Some platforms automatically restore purchases. Apple currently requires explicit purchase restoration for IAP.
        public void RestorePurchases()
        {
            // If Purchasing has not yet been set up ...
            if (!IsInitialized())
            {
                // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
                //NGUIDebug.Log ("RestorePurchases FAIL. Not initialized.");
                return;
            }
            
            // If we are running on an Apple device ... 
            if (Application.platform == RuntimePlatform.IPhonePlayer || 
                Application.platform == RuntimePlatform.OSXPlayer)
            {
                // ... begin restoring purchases
                //NGUIDebug.Log ("RestorePurchases started ...");
                
                // Fetch the Apple store-specific subsystem.
                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                // Begin the asynchronous process of restoring purchases. Expect a confirmation response in the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
                apple.RestoreTransactions((result) => {
                    // The first phase of restoration. If no more responses are received on ProcessPurchase then no purchases are available to be restored.
                /////NGUIDebug.Log ("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            // Otherwise ...
            else
            {
                // We are not running on an Apple device. No work is necessary to restore purchases.
                //NGUIDebug.Log ("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }
        
        
        //  
        // --- IStoreListener
        //
        
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            //NGUIDebug.Log ("OnInitialized: PASS");
            
            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }
        
        
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            //NGUIDebug.Log ("OnInitializeFailed InitializationFailureReason:" + error);
        }
        
        
        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
        {
            // A consumable product has been purchased by this user.
           
            if (String.Equals(args.purchasedProduct.definition.id, kProductID1000won, StringComparison.Ordinal))
            {
                //NGUIDebug.Log (string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                
                // 1000won In App Purchase 구매 보상 ( 보석 50개 지급 )
                GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + 50;
                GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);
                
                // 보석 저장.
                PlayerPrefs.SetInt("gemstone", GameData.coin_struct.gemstone);   
                PlayerPrefs.Save();
                
                // 스킬 활성화 버튼 체크
                GM.check_skills_enable_or_not();
                
            }  // Or ... a subscription product has been purchased by this user.    
            else if (String.Equals(args.purchasedProduct.definition.id, kProductID2000won, StringComparison.Ordinal))
            {
                //NGUIDebug.Log (string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                
                // 2000won In App Purchase 구매 보상 ( 보석 150개 지급 )
                GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + 150;
                GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);
                
                // 보석 저장.
                PlayerPrefs.SetInt("gemstone", GameData.coin_struct.gemstone);   
                PlayerPrefs.Save();
                
                // 스킬 활성화 버튼 체크
                GM.check_skills_enable_or_not();
                
            }  // Or ... a subscription product has been purchased by this user.      
            else if (String.Equals(args.purchasedProduct.definition.id, kProductID10000won, StringComparison.Ordinal))
            {
                //NGUIDebug.Log (string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                
                // 1000won In App Purchase 구매 보상 ( 보석 500개 지급 )
                GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + 500;
                GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);
                
                // 보석 저장.
                PlayerPrefs.SetInt("gemstone", GameData.coin_struct.gemstone);   
                PlayerPrefs.Save();
                
                // 스킬 활성화 버튼 체크
                GM.check_skills_enable_or_not();
                
            }  // Or ... a subscription product has been purchased by this user.    
            else if (String.Equals(args.purchasedProduct.definition.id, kProductID20000won, StringComparison.Ordinal))
            {
                //NGUIDebug.Log (string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                
                // 1000won In App Purchase 구매 보상 ( 보석 2000개 지급 )
                GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + 2000;
                GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_ea((ulong)GameData.coin_struct.gemstone);
                
                // 보석 저장.
                PlayerPrefs.SetInt("gemstone", GameData.coin_struct.gemstone);   
                PlayerPrefs.Save();
                
                // 스킬 활성화 버튼 체크
                GM.check_skills_enable_or_not();
                
            }  // Or ... a subscription product has been purchased by this user.            
            else
            {
                //NGUIDebug.Log (string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }// Return a flag indicating wither this product has completely been received, or if the application needs to be reminded of this purchase at next app launch. Is useful when saving purchased products to the cloud, and when that save is delayed.
            return PurchaseProcessingResult.Complete;
        }
        
        
        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing this reason with the user.
           // NGUIDebug.Log (string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",product.definition.storeSpecificId, failureReason));
        }
    }


