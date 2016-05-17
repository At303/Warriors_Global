#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("9CZ0n+hpqGpPNcaQBXSgpBvZS/GJO7ibibS/sJM/8T9OtLi4uLy5uju4trmJO7izuzu4uLkPmzov6OSjlHQ5boz1sSlM1ljBtQzT6cxMZGvIqg7ZIXYiCOT12XF5bEhYx8z+acXbpEj5jL4g01xqtaEoHhT6pAcp2TAqJxBYhjLMdRlhqivv4vWi8Rq6/RwQErcrXwIhkdSjBn3xO/b8J4SoEK+kOyZ03lkj40rLUmuCiCm1dyO8+y/aLg580L005+fFkyZfK7RUI+qnf9teSEuNxMIiS+pjbDqkSKhX7AObzOrJHbZApLSx5gP5PtsVV7+7OXomD+aWaUUHRsizndH8xk3YW9JzNPY5q7FDYQmCeEMLpPB/PFJRMFmpEeQuQru6uLm4");
        private static int[] order = new int[] { 3,3,3,5,10,11,11,11,10,11,12,13,12,13,14 };
        private static int key = 185;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
