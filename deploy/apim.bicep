@description('The email address of the publisher of the APIM resource.')
@minLength(1)
param publisherEmail string

@description('Company name of the publisher of the APIM resource.')
@minLength(1)
param publisherName string

@description('Location for Azure resources.')
param location string

param serviceUrl string

var random = uniqueString(resourceGroup().id)
var apimName = toLower('apim-${random}')

resource apim 'Microsoft.ApiManagement/service@2020-12-01' = {
  name: apimName
  location: location
  sku:{
    capacity: 1
    name: 'Consumption'
  }
  properties:{
    publisherEmail: publisherEmail
    publisherName: publisherName
  }

  resource api 'apis' = {
    name:'ExpenseManagement'
    properties:{         
      path:'expense'
      description:'Contoso Expense Management API'
      apiType:'http'
      protocols: [
        'http'
      ]
      displayName:'Contoso Expense Management API'
      subscriptionRequired:false
      isCurrent:true
      serviceUrl: serviceUrl
    }
  }    
}

var apim_endpoint = apim.properties.gatewayUrl
output swagger_endpoint string = '${apim_endpoint}/expense/swagger/v1/swagger.json'
