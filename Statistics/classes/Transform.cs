namespace Statistics.classes
{
    internal class Transform
    {
        public static Int64 ToBitmap(string[] values) {
            Int64 result = 0;

            for (int i = 0; i < values.Length; i++) {
                result |= 1 << (int.Parse(values[i]) - 1);
            }

            return result;
        }

        public static Int64 ToBitmap(int[] values) {
            Int64 result = 0;

            for (int i = 0; i < values.Length; i++) {
                result |= 1 << (values[i] - 1);
            }

            return result;
        }

        public static List<long> CreateBitmapRange(int start, int length, int limit) {
            List<long> result = new List<long>();

            result.Add(0);
            for (int i = 0; i < length; i++) {
                result[0] |= 1 << ((start - 1) + i);
            }

            
            for(int i = 0; i < length; i++) {
                for (int j = length - i; j < limit - i; j++) {
                    long temp = result.Last();
                    temp |= 1 << (j);
                    temp -= 1 << (j - 1);
                    
                    result.Add(temp);
                }
            }
            

            return result;
        }

        public static string GetSequence(long bitmap, int limit) {
            List<string> result = new List<string>();

            for (int i = 0; i < limit; i++) {
                if ((bitmap & (1 << i)) != 0) {
                    result.Add((i + 1).ToString());
                }
            }
            
            return string.Join(";", result);
        } 
    }
}
