Imports System.Data.SQLite
Imports System.Xml

Module Module1

    Sub Main()
        Dim intMenuOption As Integer = 0
        Dim webClient As New System.Net.WebClient
        Dim strSteamOwnedGames As String
        Dim iosFileWriter As System.IO.StreamWriter
        Dim xmlSteamOwnedGames As New XmlDocument
        Dim xmlSteamGame As XmlNode
        Dim sqlConnection As New SQLiteConnection
        Dim sqlCreateDbCommand As New SQLiteCommand("CREATE TABLE IF NOT EXISTS GAMES(Id INTEGER PRIMARY KEY, Name TEXT, SteamAppId TEXT, SteamAppPlayed TEXT, SteamIconURL TEXT, SteamLogoURL TEXT);", sqlConnection)
        Dim sqlAddSteamGameCommand As New SQLiteCommand("INSERT INTO GAMES (Name, SteamAppId, SteamAppPlayed, SteamIconURL, SteamLogoURL) VALUES(@Name, @SteamAppId, @SteamAppPlayed, @SteamIconURL, @SteamLogoURL);", sqlConnection)
        Dim strConnectionString As String = "URI=file:" & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\gamelib.sqlite"
        Dim strSteamAppId As String
        Dim strAppName As String
        Dim strSteamAppPlayed As String
        Dim strSteamIconURL As String
        Dim strSteamLogoURL As String

        sqlConnection.ConnectionString = strConnectionString
        sqlConnection.Open()
        sqlCreateDbCommand.ExecuteNonQuery()

        While intMenuOption <> 3
            If My.Settings.SteamID = "" Then
                Console.WriteLine("Enter your Steam ID:")
                My.Settings.SteamID = Console.ReadLine
            Else
                Console.WriteLine("Steam ID is " & My.Settings.SteamID)
            End If

            If My.Settings.SteamKey = "" Then
                Console.WriteLine("Enter your Steam Key:")
                My.Settings.SteamKey = Console.ReadLine
            Else
                Console.WriteLine("Steam Key is " & My.Settings.SteamKey)
            End If
            My.Settings.Save()
            Console.WriteLine("")
            Console.WriteLine("Menu")
            Console.WriteLine("(1) Reset ID and Key")
            Console.WriteLine("(2) Download game catalog")
            Console.WriteLine("(3) Exit")
            Console.WriteLine("")
            Console.WriteLine("Enter an option:")
            intMenuOption = Int(Console.ReadLine)

            Select Case intMenuOption
                Case 1
                    My.Settings.SteamID = ""
                    My.Settings.SteamKey = ""
                Case 2
                    strSteamOwnedGames = webClient.DownloadString("https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=" & My.Settings.SteamKey & "&steamid=" & My.Settings.SteamID & "&include_appinfo=1&include_played_free_games=1&format=xml")

                    Console.WriteLine("Saving data to " & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
                    iosFileWriter = New System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\rawdata.txt")
                    iosFileWriter.Write(strSteamOwnedGames)
                    iosFileWriter.Close()

                    xmlSteamOwnedGames.LoadXml(strSteamOwnedGames)
                    For Each xmlSteamGame In xmlSteamOwnedGames.SelectNodes("response/games/message")
                        strSteamAppId = xmlSteamGame.SelectSingleNode("appid").InnerText
                        strAppName = xmlSteamGame.SelectSingleNode("name").InnerText
                        strSteamAppPlayed = xmlSteamGame.SelectSingleNode("playtime_forever").InnerText
                        strSteamIconURL = xmlSteamGame.SelectSingleNode("img_icon_url").InnerText
                        strSteamLogoURL = xmlSteamGame.SelectSingleNode("img_logo_url").InnerText

                        Console.WriteLine(strAppName & " (" & strSteamAppId & ")")

                        With sqlAddSteamGameCommand
                            .Parameters.Add("@Name", SqlDbType.VarChar).Value = strAppName
                            .Parameters.Add("@SteamAppId", SqlDbType.VarChar).Value = strSteamAppId
                            .Parameters.Add("@SteamAppPlayed", SqlDbType.VarChar).Value = strSteamAppPlayed
                            .Parameters.Add("@SteamIconURL", SqlDbType.VarChar).Value = strSteamIconURL
                            .Parameters.Add("@SteamLogoURL", SqlDbType.VarChar).Value = strSteamLogoURL
                            .ExecuteNonQuery()
                        End With

                    Next

                    Console.WriteLine("")
                Case 3
                    sqlConnection.Close()
                    End
            End Select
        End While
    End Sub

End Module
