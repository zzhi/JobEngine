#region License

/* 
 * All content copyright Terracotta, Inc., unless otherwise indicated. All rights reserved. 
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not 
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at 
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0 
 *   
 * Unless required by applicable law or agreed to in writing, software 
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations 
 * under the License.
 * 
 */

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using Quartz.Util;

namespace Quartz
{
    /// <summary>
    /// Holds state information for <see cref="IJob" /> instances.
    /// </summary>
    /// <remarks>
    /// <see cref="JobDataMap" /> instances are stored once when the <see cref="IJob" />
    /// is added to a scheduler. They are also re-persisted after every execution of
    /// instances that have <see cref="PersistJobDataAfterExecutionAttribute" /> present.
    /// <para>
    /// <see cref="JobDataMap" /> instances can also be stored with a 
    /// <see cref="ITrigger" />.  This can be useful in the case where you have a Job
    /// that is stored in the scheduler for regular/repeated use by multiple 
    /// Triggers, yet with each independent triggering, you want to supply the
    /// Job with different data inputs.  
    /// </para>
    /// <para>
    /// The <see cref="IJobExecutionContext" /> passed to a Job at execution time 
    /// also contains a convenience <see cref="JobDataMap" /> that is the result
    /// of merging the contents of the trigger's JobDataMap (if any) over the
    /// Job's JobDataMap (if any).  
    /// </para>
    /// </remarks>
    /// <seealso cref="IJob" />
    /// <seealso cref="PersistJobDataAfterExecutionAttribute" />
    /// <seealso cref="ITrigger" />
    /// <seealso cref="IJobExecutionContext" />
    /// <author>James House</author>
    /// <author>Marko Lahma (.NET)</author>
#if BINARY_SERIALIZATION
    [Serializable]
#endif // BINARY_SERIALIZATION
    public class JobDataMap : StringKeyDirtyFlagMap
    {
        /// <summary>
        /// Create an empty <see cref="JobDataMap" />.
        /// </summary>
        public JobDataMap() : base(15)
        {
        }

        /// <summary> 
        /// Create a <see cref="JobDataMap" /> with the given data.
        /// </summary>
        public JobDataMap(IDictionary<string, object> map) : this()
        {
            PutAll(map);
        }

        /// <summary> 
        /// Create a <see cref="JobDataMap" /> with the given data.
        /// </summary>
        public JobDataMap(IDictionary map) : this()
        {
            foreach (DictionaryEntry entry in map)
            {
                Put((string) entry.Key, entry.Value);
            }
        }

#if BINARY_SERIALIZATION
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected JobDataMap(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif // BINARY_SERIALIZATION

        /// <summary>
        /// Adds the given <see cref="bool" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, bool value)
        {
            string strValue = value.ToString();
            base.Put(key, strValue);
        }


        /// <summary>
        /// Adds the given <see cref="char" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, char value)
        {
            string strValue = value.ToString();
            base.Put(key, strValue);
        }

        /// <summary>
        /// Adds the given <see cref="double" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, double value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture);
            base.Put(key, strValue);
        }


        /// <summary>
        /// Adds the given <see cref="float" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, float value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture);
            base.Put(key, strValue);
        }


        /// <summary>
        /// Adds the given <see cref="int" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, int value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture);
            base.Put(key, strValue);
        }


        /// <summary>
        /// Adds the given <see cref="long" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, long value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture);
            base.Put(key, strValue);
        }

        /// <summary>
        /// Adds the given <see cref="DateTime" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, DateTime value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture);
            base.Put(key, strValue);
        }

        /// <summary>
        /// Adds the given <see cref="DateTimeOffset" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, DateTimeOffset value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture);
            base.Put(key, strValue);
        }

        /// <summary>
        /// Adds the given <see cref="TimeSpan" /> value as a string version to the
        /// <see cref="IJob" />'s data map.
        /// </summary>
        public virtual void PutAsString(string key, TimeSpan value)
        {
            string strValue = value.ToString();
            base.Put(key, strValue);
        }

        /// <summary>
        /// Retrieve the identified <see cref="int" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual int GetIntValueFromString(string key)
        {
            object obj = Get(key);
            return int.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="int" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual int GetIntValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetIntValueFromString(key);
            }

            return GetInt(key);
        }

        /// <summary>
        /// Retrieve the identified <see cref="bool" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual bool GetBooleanValueFromString(string key)
        {
            object obj = Get(key);

            return CultureInfo.InvariantCulture.TextInfo.ToUpper((string) obj).Equals("TRUE");
        }

        /// <summary>
        /// Retrieve the identified <see cref="bool" /> value from the 
        /// <see cref="JobDataMap" />.
        /// </summary>
        public virtual bool GetBooleanValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetBooleanValueFromString(key);
            }

            return GetBoolean(key);
        }

        /// <summary>
        /// Retrieve the identified <see cref="char" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual char GetCharFromString(string key)
        {
            object obj = Get(key);

            return ((string) obj)[0];
        }

        /// <summary>
        /// Retrieve the identified <see cref="double" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual double GetDoubleValueFromString(string key)
        {
            object obj = Get(key);
            return double.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="double" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual double GetDoubleValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetDoubleValueFromString(key);
            }

            return GetDouble(key);
        }

        /// <summary>
        /// Retrieve the identified <see cref="float" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual float GetFloatValueFromString(string key)
        {
            object obj = Get(key);
            return float.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="float" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual float GetFloatValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetFloatValueFromString(key);
            }

            return GetFloat(key);
        }

        /// <summary>
        /// Retrieve the identified <see cref="long" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual long GetLongValueFromString(string key)
        {
            object obj = Get(key);
            return long.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="DateTime" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual DateTime GetDateTimeValueFromString(string key)
        {
            object obj = Get(key);
            return DateTime.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="DateTimeOffset" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual DateTimeOffset GetDateTimeOffsetValueFromString(string key)
        {
            object obj = Get(key);
            return DateTimeOffset.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="TimeSpan" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual TimeSpan GetTimeSpanValueFromString(string key)
        {
            object obj = Get(key);
            return TimeSpan.Parse((string) obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Retrieve the identified <see cref="long" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual long GetLongValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetLongValueFromString(key);
            }

            return GetLong(key);
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual DateTime GetDateTimeValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetDateTimeValueFromString(key);
            }

            return GetDateTime(key);
        }

        /// <summary>
        /// Gets the date time offset.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual DateTimeOffset GetDateTimeOffsetValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetDateTimeOffsetValueFromString(key);
            }

            return GetDateTimeOffset(key);
        }

        /// <summary>
        /// Retrieve the identified <see cref="TimeSpan" /> value from the <see cref="JobDataMap" />.
        /// </summary>
        public virtual TimeSpan GetTimeSpanValue(string key)
        {
            object obj = Get(key);

            if (obj is string)
            {
                return GetTimeSpanValueFromString(key);
            }

            return GetTimeSpan(key);
        }
    }
}