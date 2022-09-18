resource les_domain 'Microsoft.EventGrid/domains@2022-06-15' = {
  name: 'les-domain'
  location: 'northeurope'
  identity: {
    type: 'None'
  }
  properties: {
    inputSchema: 'EventGridSchema'
    publicNetworkAccess: 'Enabled'
    inboundIpRules: []
    disableLocalAuth: false
    dataResidencyBoundary: 'WithinGeopair'
  }
}

resource les_domain_eventgridtrigger 'Microsoft.EventGrid/domains/topics@2022-06-15' = {
  parent: les_domain
  name: 'eventgridtrigger'
}

resource les_domain_eventgridtrigger_EventGridTrigger 'Microsoft.EventGrid/domains/topics/eventSubscriptions@2022-06-15' = {
  parent: les_domain_eventgridtrigger
  name: 'EventGridTrigger'
  properties: {
    destination: {
      properties: {
        resourceId: '/subscriptions/3d3b15f1-193f-40a9-986d-40c56c9a21bb/resourceGroups/rg-grid-poc/providers/Microsoft.Web/sites/les-acl/functions/EventGridTrigger'
        maxEventsPerBatch: 1
        preferredBatchSizeInKilobytes: 64
      }
      endpointType: 'AzureFunction'
    }
    filter: {
      enableAdvancedFilteringOnArrays: true
    }
    labels: []
    eventDeliverySchema: 'EventGridSchema'
    retryPolicy: {
      maxDeliveryAttempts: 30
      eventTimeToLiveInMinutes: 1440
    }
  }
  dependsOn: [

    les_domain
  ]
}
