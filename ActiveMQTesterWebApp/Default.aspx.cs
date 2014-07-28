using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActiveMQHandler;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace ActiveMQTesterWebApp
{
    public partial class AMQClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int numRequests;
                if (Request["numrequests"] != null)
                {
                    if (int.TryParse(Request["numrequests"], out numRequests))
                        DoSeach(numRequests);
                }
            }
        }

        private void DoSeach(int numRequests)
        {
            StringBuilder resp = new StringBuilder();

            ActiveMQWriter w = new ActiveMQWriter(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["RQQueue"]);
            string id = Guid.NewGuid().ToString();

            w.WriteMessageListToQueue(CreateRequestList(numRequests, id), false);


            ActiveMQReader r = new ActiveMQReader(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["RSQueue"]);
            bool nextMessage = true;
            int i = 0;
            int count = 0;
            while (count <= numRequests * 100)
            {
//                Thread.Sleep(100);
                Tuple<string, string> tup = r.ReadMessage(id);
                nextMessage = tup.Item1 != null;
                if (nextMessage)
                {
                    resp.Append(tup.Item1 + ", ");
                    i++;
                    if (i >= numRequests)
                        break;
                }
                count++;
            }

            resp.Append("Total = " + i);
            litResponse.Text = resp.ToString();
            r = null;
            w = null;
            resp = null;
        }

        private List<Tuple<string, string>> CreateRequestList(int numRequests, string id)
        {
            List<Tuple<string, string>> rList = new List<Tuple<string, string>>();

            for (int i = 0; i < numRequests; i++)
            {
                Tuple<string, string> t = Tuple.Create(id, RequesSample);
                rList.Add(t);
            }
            return rList;
        }

        private static string RequesSample = @"<desiredOutboundDate>2014-10-15T20:00:00</desiredOutboundDate>
	<outboundDateKind>1</outboundDateKind>
	<desiredInboundDate>2014-10-30T09:00:00</desiredInboundDate>
	<inboundDateKind>0</inboundDateKind>
	<flags>
		<includePublicTransp>false</includePublicTransp>
	</flags>
	<oriLocation>
		<lat>-23.5732853</lat>
		<lng>-46.64167550000002</lng>
		<type>street_address</type>
	</oriLocation>
	<destLocation>
		<lat>52.3661876</lat>
		<lng>4.899111500000004</lng>
		<type>route</type>
	</destLocation>
	<chosenRoute>
		<flightSegment>
			<flightLegs>
				<origin>GRU</origin>
				<destination>LHR</destination>
				<number>246</number>
				<marketingAirline>BA</marketingAirline>
				<operatingAirline></operatingAirline>
				<departureDate>2014-10-14T16:15:00</departureDate>
				<arrivalDate>2014-10-15T07:20:00</arrivalDate>
				<fareClass></fareClass>
				<fareBasis></fareBasis>
				<duration>665</duration>
				<distance>0</distance>
			</flightLegs>
			<flightLegs>
				<origin>LHR</origin>
				<destination>AMS</destination>
				<number>430</number>
				<marketingAirline>BA</marketingAirline>
				<operatingAirline></operatingAirline>
				<departureDate>2014-10-15T08:20:00</departureDate>
				<arrivalDate>2014-10-15T10:40:00</arrivalDate>
				<fareClass></fareClass>
				<fareBasis></fareBasis>
				<duration>80</duration>
				<distance>0</distance>
			</flightLegs>
		</flightSegment>
		<segmentIndex>1</segmentIndex>
		<routeIndex>0</routeIndex>
		<price>2700</price>
		<currency>BRL</currency>
	</chosenRoute>
	<chosenRoute>
		<flightSegment>
			<flightLegs>
				<origin>AMS</origin>
				<destination>FRA</destination>
				<number>999</number>
				<marketingAirline>LH</marketingAirline>
				<operatingAirline></operatingAirline>
				<departureDate>2014-10-30T19:45:00</departureDate>
				<arrivalDate>2014-10-30T20:55:00</arrivalDate>
				<fareClass></fareClass>
				<fareBasis></fareBasis>
				<duration>70</duration>
				<distance>0</distance>
			</flightLegs>
			<flightLegs>
				<origin>FRA</origin>
				<destination>GRU</destination>
				<number>506</number>
				<marketingAirline>LH</marketingAirline>
				<operatingAirline></operatingAirline>
				<departureDate>2014-10-30T21:55:00</departureDate>
				<arrivalDate>2014-10-31T04:55:00</arrivalDate>
				<fareClass></fareClass>
				<fareBasis></fareBasis>
				<duration>720</duration>
				<distance>0</distance>
			</flightLegs>
		</flightSegment>
		<segmentIndex>1</segmentIndex>
		<routeIndex>0</routeIndex>
		<price>2200</price>
		<currency>BRL</currency>
	</chosenRoute>
	<chosenStay>
		<location>
			<lat>-30.032387</lat>
			<lng>-51.17801399999996</lng>
			<type>lodging</type>
		</location>
		<totalPrice>0</totalPrice>
		<completeStay>true</completeStay>
		<checkinDate />
		<checkoutDate />
	</chosenStay>";
        
    }
}