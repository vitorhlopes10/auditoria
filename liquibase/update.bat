liquibase --url="jdbc:jtds:sqlserver://localhost:1433;instance=LOCAL2012;databaseName=CFC.AUDITORIA" --changeLogFile="%cd%\changelog.xml" --username="sa" --password="123456" --driver="net.sourceforge.jtds.jdbc.Driver" --classpath="C:\\liquibase\\driver\\jtds-1.3.1.jar" update