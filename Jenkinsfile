pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/core/sdk:3.1'
    }

  }
  stages {
    stage('Build EF') {
      steps {
        sh 'dotnet build MyAirport.EF -c Release'
      }
    }

    stage('Build EF Clients') {
      parallel {
        stage('Build WebApi') {
          steps {
            sh 'dotnet build MyAirport.WebApi -c Release'
          }
        }
        
        stage('Build GraphQLWebApi') {
          steps {
            sh 'dotnet build MyAirport.GraphQLWebApi -c Release'
          }
        }

        stage('Build ConsoleApp') {
          steps {
            sh 'dotnet build MyAirport.ConsoleApp -c Release'
          }
        }
        
        stage('Build RazorApplication') {
          steps {
            sh 'dotnet build MyAirport.Razor -c Release'
          }
        }
      }
    }

    stage('Test WebApi') {
      steps {
        sleep 1
      }
    }

  }
  environment {
    HOME = '/tmp'
    DOTNET_CLI_TELEMETRY_OPTOUT = '1'
  }
}