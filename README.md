# relayexternalapi
Azure Service Bus Relay Demonstration

Configure External Resource - WebAPI in this example

1.  In the WCF Service project, install NuGet package:  ``` Install-Package WindowsAzure.ServiceBus ```
2.  A bunch of extensions will be added into your projects' web.config file
3.  Update web.config.  Main parts are: client endpoint and endpoint behavior

```
  <system.serviceModel>
    <client>
      <!-- For local -->
      <!--<endpoint name="SanDiegoSurfSpot" address="http://localhost/relayinternal/SanDiegoSpots.svc" binding="basicHttpBinding" contract="SurfSpots.Contracts.ISanDiegoSpots" />-->
      <endpoint name="SanDiegoSurfSpot_SB" binding="netTcpRelayBinding" address="sb://relaytester.servicebus.windows.net/surfspot" contract="SurfSpots.Contracts.ISanDiegoSpots" behaviorConfiguration="sbTokenProvider" />
    </client>
    <behaviors>
      <endpointBehaviors>
        <behavior name="sbTokenProvider">
          <transportClientEndpointBehavior>
            <tokenProvider>
              <sharedAccessSignature keyName="RootManageSharedAccessKey" key="tveyH2hVHrm9+mtgqUGbZ+M7xcyXbH/twhB4P2Qvx1o=" />
            </tokenProvider>
          </transportClientEndpointBehavior>
        </behavior>
      </endpointBehaviors>
    </behaviors>
  </system.serviceModel>
```
