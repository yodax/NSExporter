using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace NSExporter.Test
{
    internal class WhenParsingServerInformation
    {
        [Test]
        public void TheVersionShouldBeRetrieved()
        {
            var version = NightscoutVersion.FromJson(_statusJsonResult);
            version.VersionString.Should().Be("14.2.6");
        }

        private string _statusJsonResult =
            "{\"status\":\"ok\",\"name\":\"nightscout\",\"version\":\"14.2.6\",\"serverTime\":\"2022-01-24T12:03:07.033Z\",\"serverTimeEpoch\":1643025787033,\"apiEnabled\":true,\"careportalEnabled\":true,\"boluscalcEnabled\":false,\"settings\":{\"units\":\"mmol\",\"timeFormat\":24,\"dayStart\":7,\"dayEnd\":21,\"nightMode\":false,\"editMode\":true,\"showRawbg\":\"never\",\"customTitle\":\"Nightscout\",\"theme\":\"colors\",\"alarmUrgentHigh\":true,\"alarmUrgentHighMins\":[30,60,90,120],\"alarmHigh\":true,\"alarmHighMins\":[30,60,90,120],\"alarmLow\":true,\"alarmLowMins\":[15,30,45,60],\"alarmUrgentLow\":true,\"alarmUrgentLowMins\":[15,30,45],\"alarmUrgentMins\":[30,60,90,120],\"alarmWarnMins\":[30,60,90,120],\"alarmTimeagoWarn\":true,\"alarmTimeagoWarnMins\":15,\"alarmTimeagoUrgent\":true,\"alarmTimeagoUrgentMins\":30,\"alarmPumpBatteryLow\":false,\"language\":\"nl\",\"scaleY\":\"linear\",\"showPlugins\":\"openaps pump sage basal careportal iob cage treatments cob delta direction upbat\",\"showForecast\":\"openaps\",\"focusHours\":3,\"heartbeat\":\"20\",\"baseURL\":\"https://xxx.com\",\"authDefaultRoles\":\"readable\",\"thresholds\":{\"bgHigh\":252,\"bgTargetTop\":180,\"bgTargetBottom\":72,\"bgLow\":70},\"insecureUseHttp\":true,\"secureHstsHeader\":true,\"secureHstsHeaderIncludeSubdomains\":false,\"secureHstsHeaderPreload\":false,\"secureCsp\":false,\"deNormalizeDates\":false,\"showClockDelta\":false,\"showClockLastTime\":false,\"frameUrl1\":\"\",\"frameUrl2\":\"\",\"frameUrl3\":\"\",\"frameUrl4\":\"\",\"frameUrl5\":\"\",\"frameUrl6\":\"\",\"frameUrl7\":\"\",\"frameUrl8\":\"\",\"frameName1\":\"\",\"frameName2\":\"\",\"frameName3\":\"\",\"frameName4\":\"\",\"frameName5\":\"\",\"frameName6\":\"\",\"frameName7\":\"\",\"frameName8\":\"\",\"authFailDelay\":5000,\"adminNotifiesEnabled\":true,\"DEFAULT_FEATURES\":[\"bgnow\",\"delta\",\"direction\",\"timeago\",\"devicestatus\",\"upbat\",\"errorcodes\",\"profile\",\"bolus\",\"dbsize\",\"runtimestate\",\"basal\",\"careportal\"],\"alarmTypes\":[\"predict\"],\"enable\":[\"bridge\",\"openaps\",\"careportal\",\"iob\",\"profile\",\"cage\",\"bage\",\"cob\",\"basal\",\"treatments\",\"sage\",\"pump\",\"cors\",\"pushover\",\"treatmentnotify\",\"bgnow\",\"delta\",\"direction\",\"timeago\",\"devicestatus\",\"upbat\",\"errorcodes\",\"bolus\",\"runtimestate\",\"ar2\"]},\"extendedSettings\":{\"timeago\":{\"enableAlerts\":false},\"upbat\":{\"enableAlerts\":true,\"warn\":15,\"urgent\":10},\"pump\":{\"warnBattU\":30,\"fields\":\"battery reservoir status\",\"retroFields\":\"resevoir battery\",\"enableAlerts\":true,\"warnRes\":15,\"urgentRes\":10,\"urgentBattU\":20,\"urgentBattV\":1.25,\"warnOnSuspend\":true,\"warnClock\":120,\"urgentClock\":150},\"openaps\":{\"fields\":\"status-symbol status-label iob meal-assist\",\"enableAlerts\":true,\"colorPredictionLines\":true},\"cage\":{\"enableAlerts\":true,\"info\":48,\"warn\":72,\"urgent\":96},\"sage\":{\"enableAlerts\":true,\"info\":216,\"warn\":232,\"urgent\":240},\"bage\":{\"urgent\":192,\"warn\":168,\"enableAlerts\":true},\"basal\":{\"render\":\"default\"},\"profile\":{\"history\":true,\"multiple\":false},\"devicestatus\":{\"advanced\":true,\"days\":1}},\"authorized\":null,\"runtimeState\":\"loaded\"}";
    }
}
