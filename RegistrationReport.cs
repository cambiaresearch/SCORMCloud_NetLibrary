/* Software License Agreement (BSD License)
 *
 * Copyright (c) 2010-2011, Rustici Software, LLC
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the <organization> nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL Rustici Software, LLC BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;

namespace RusticiSoftware.HostedEngine.Client
{
    /// <summary>
    /// https://cloud.scorm.com/docs/api_reference/registration.html#getregistrationresult
    /// </summary>
    public class RegistrationReport
    {
        private String _Complete;
        private string _InstanceId;
        private string _RegistrationId;
        private RegistrationResultsFormat _ResultsFormat;
        private String _Score;
        private String _Success;
        private String _TotalSeconds;
        public RegistrationReport(XmlElement reportElem)
        {
            Init(reportElem);
        }

        public String Complete
        {
            get { return _Complete; }
            set { _Complete = value; }
        }
        public string InstanceId
        {
            get { return _InstanceId; }
        }
        public string RegistrationId
        {
            get { return _RegistrationId; }
        }
        public RegistrationResultsFormat ResultsFormat
        {
            get
            {
                return _ResultsFormat;
            }
        }
        public String Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        public String Success
        {
            get { return _Success; }
            set { _Success = value; }
        }
        public String TotalSeconds
        {
            get { return _TotalSeconds; }
            set { _TotalSeconds = value; }
        }

        private void Init()
        {
            _ResultsFormat = RegistrationResultsFormat.COURSE;
            _InstanceId = "";
            _RegistrationId = "";
            _Complete = "";
            _Success = "";
            _TotalSeconds = "";
            _Score = "";
        }
        private void Init(XmlElement reportElem)
        {
            Init();

            _ResultsFormat = (RegistrationResultsFormat)Enum.Parse(typeof(RegistrationResultsFormat), reportElem.Attributes["format"].Value, true);
            _RegistrationId = reportElem.Attributes["regid"].Value;
            _InstanceId = reportElem.Attributes["instanceid"].Value;

            if (_ResultsFormat == RegistrationResultsFormat.ACTIVITY)
            {
            }
            else if (_ResultsFormat == RegistrationResultsFormat.FULL)
            {
            }
            else
            {
                this.Complete = reportElem.GetElementsByTagName("complete")[0].InnerText;
                this.Success = reportElem.GetElementsByTagName("success")[0].InnerText;
                this.TotalSeconds = reportElem.GetElementsByTagName("totaltime")[0].InnerText;
                this.Score = reportElem.GetElementsByTagName("score")[0].InnerText;
            }
        }
    }
}
