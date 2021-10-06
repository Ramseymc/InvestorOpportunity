using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorLibrary.Shared
{
    public static class ExtentionMethods
    {
        public static bool IsBoolean(this Object source)
        {
            return source.Equals(typeof(Boolean));
        }

        public static bool IsBoolean(this string value)
        {
            if (bool.TryParse(value.ToString(), out _))
            {
                return true;
            }

            return false;
        }


        public static bool IsNotBoolean(this string value)
        {
            if (!bool.TryParse(value.ToString(), out _))
            {
                return true;
            }

            return false;
        }

        public static bool IsNotBoolean(this Object source)
        {
            return !source.Equals(typeof(Boolean));
        }


        public static bool IsNumeric(this string value)
        {
            return value != null && value != "" && long.TryParse(value, out _);
        }


        public static bool IsNotNumeric(this string value)
        {
            return value == null || !long.TryParse(value, out _);
        }


        public static bool IsDouble(this string value)
        {
            return value != null || double.TryParse(value, out _);
        }

        public static bool IsDate(this string value)
        {
            return value != null || DateTime.TryParse(value, out _);
        }

        public static bool IsNotNullorWhiteSpace(this string value)
        {
            if (value != null && value != "")
            {
                return true;
            }

            return false;
        }

        public static bool IsNullorWhiteSpace(this string value)
        {
            if (value == null || value == "")
            {
                return true;
            }

            return false;
        }



        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection != null || collection.Count() != 0;
        }


        public static bool IsNotNull<T>(this IEnumerable<T> collection)
        {
            return collection != null;
        }

        public static bool IsNotNullObject(this object source)
        {
            return source != null;
        }

        public static bool IsNullObject(this object source)
        {
            return source == null;
        }


        public static bool IsNullorEmpty(this object source)
        {
            return source == null || source.ToString() == "";
        }

        public static string GetStringValue(this object source)
        {
            if (source.IsNullorEmpty())
            {
                return "";
            }
            else
            {
                return source.ToString();
            }
        }


        public static string GetIdValue(this object source)
        {
            if (IsNullObject(source))
            {
                return "0";
            }

            if (int.TryParse(source.ToString(), out _))
            {
                return source.ToString();
            }
            else
            {
                return "0";
            }
        }


        public static string GetBoolOrNull(this object source)
        {
            if (IsNullObject(source))
            {
                return "false";
            }

            if (bool.TryParse(source.ToString(), out _))
            {
                return source.ToString();
            }
            else
            {
                return "false";
            }
        }

        public static void SelectItemByValue(this ComboBox cbo, string value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                var prop = cbo.Items[i].GetType().GetProperty(cbo.ValueMember);
                if (prop != null && prop.GetValue(cbo.Items[i], null).ToString() == value)
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }



        public static bool InputIsNumber(this char text)
        {
            return char.IsNumber(text) || char.IsWhiteSpace(text) || text == '-' || char.IsControl(text);
        }

        public static bool InputIsText(this char text)
        {
            return char.IsNumber(text) || char.IsLetter(text) || char.IsWhiteSpace(text) || char.IsControl(text);
        }

        public static bool InputIsDecimal(this char text)
        {
            return char.IsNumber(text) || char.IsWhiteSpace(text) || text == '.' || text == '-' || char.IsControl(text);
        }




        public static string GetStringValue(this string value)
        {
            if (value.IsNullorEmpty())
            {
                return null;
            }
            else
            {
                return value.ToString();
            }
        }


        public static long GetNumberValue(this string value)
        {
            if (IsNullObject(value))
            {
                return 0;
            }

            if (int.TryParse(value.ToString(), out _))
            {
                return int.Parse(value.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static long? GetNumberOrNull(this string value)
        {
            if (IsNullObject(value))
            {
                return null;
            }

            if (int.TryParse(value.ToString(), out _))
            {
                if (int.Parse(value.ToString()) != 0)
                {
                    return int.Parse(value.ToString());
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }


        public static double GetDoubleValue(this string value)
        {
            if (IsNullObject(value))
            {
                return 0;
            }

            if (double.TryParse(value.ToString(), out _))
            {
                return double.Parse(value.ToString());
            }
            else
            {
                return 0;
            }
        }


        public static double? GetDoubleOrNull(this string value)
        {
            if (IsNullObject(value))
            {
                return null;
            }

            if (double.TryParse(value.ToString(), out _))
            {
                if (double.Parse(value.ToString()) != 0)
                {
                    return double.Parse(value.ToString());
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }


        public static bool GetBoolValue(this string value)
        {
            if (IsNullObject(value))
            {
                return false;
            }

            if (bool.TryParse(value.ToString(), out _))
            {
                return bool.Parse(value.ToString());
            }
            else
            {
                return false;
            }
        }


        public static bool? GetBoolOrNull(this string value)
        {
            if (IsNullObject(value))
            {
                return null;
            }

            if (bool.TryParse(value.ToString(), out _))
            {
                return bool.Parse(value.ToString());
            }
            else
            {
                return null;
            }
        }

        public static DateTime GetDateValue(this string value)
        {
            if (IsNullObject(value))
            {
                return DateTime.Now;
            }

            if (DateTime.TryParse(value.ToString(), out _))
            {
                return DateTime.Parse(value.ToString());
            }
            else
            {
                return DateTime.Now;
            }
        }


        public static DateTime? GetDateorNull(this string value)
        {
            if (IsNullObject(value))
            {
                return null;
            }

            if (DateTime.TryParse(value.ToString(), out _))
            {
                return DateTime.Parse(value.ToString());
            }
            else
            {
                return null;
            }
        }


    }
}
