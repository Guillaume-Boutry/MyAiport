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

    stage('Build WebApi') {
      parallel {
        stage('Build WebApi') {
          steps {
            sh 'dotnet build MyAirport.WebApi -c Release'
          }
        }

        stage('Build ConsoleApp') {
          steps {
            sh 'dotnet build MyAirport.ConsoleApp -c Release'
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