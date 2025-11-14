alias MapLibre, as: Ml

# List of countries of various categories
# source: https://ec.europa.eu/eurostat/statistics-explained/index.php?title=Glossary:Country_codes
countries_eu =
  "BE,BG,CZ,DK,DE,EE,IE,EL,ES,FR,GR,HR,IT,CY,LV,LT,LU,HU,MT,NL,AT,PL,PT,RO,DI,DK,FI,SE"
  |> String.split(",")
countries_efta =
  "IS,LI,NO,CH"
  |> String.split(",")
countries_eu_cand =
  "BA,ME,MD,MK,GE,AL,RS,TR,UA"
  |> String.split(",")
countries_enp =
  "AM,BY,AZ,DZ,EG,IL,JO,LB,LY,MA,PS,SY,TN"
  |> String.split(",")
countries_other =
  "AR,AU,BR,CA,CN,CM_X_HK,HK,IN,JP,MX,NG,NZ,RU,SG,ZA,KR,TW,UK,US"
  |> String.split(",")
countries_interest =
  [
    countries_eu,
    countries_efta,
    countries_eu_cand,
    countries_enp,
    countries_other
  ]
  |> List.flatten()

# data source
url = "https://raw.githubusercontent.com/ip2location/ip2location-iata-icao/master/iata-icao.csv"

# fetch data and split it into lines
file =
  url
  |> Req.get!()
  |> Map.get(:body)
  |> String.replace("\",\"", "\"|\"", global: true)
  |> String.replace("\"", "", global: true)
  |> String.split("\r\n")

# split lines into header and data lines
[header_line|contents_lines] = file

# parse the header into a name-to-index map
index =
  header_line
  |> String.split("|")
  |> Enum.with_index()
  |> Map.new()

# parse data lines according to header map to obtain a list of airports
airports =
  contents_lines
  |> Enum.filter(fn line -> line != "" end)
  |> Enum.map(
    fn line ->
      elements =
        line
        |> String.split("|")
      index
      |> Enum.reduce(%{},
        fn {key, i}, acc ->
          Map.put(acc, key,
            case {key, Enum.at(elements, i)} do
              {"latitude", value} -> Float.parse(value) |> elem(0)
              {"longitude", value} -> Float.parse(value) |> elem(0)
              {_, value} -> value
            end
          )
        end
      )
    end
  )

# define list of markers to place on map
markers =
  airports
  |> Enum.filter(fn %{"country_code" => country} -> Enum.member?(countries_interest, country) end)
  |> Enum.map(
    fn %{"latitude" => lat, "longitude" => long, "airport" => _name, "country_code" => country} ->
      [
        {long, lat},
        scale: 0.5,
        color:
          cond do
            # String.contains?(name, "International") -> "red"
            country=="DK" -> "red"
            Enum.member?(countries_eu, country) -> "blue"
            Enum.member?(countries_efta, country) -> "cyan"
            Enum.member?(countries_eu_cand, country) -> "green"
            Enum.member?(countries_enp, country) -> "orange"
            Enum.member?(countries_other, country) -> "white"
            true -> "black"
          end
      ]
    end
  )

# produce map
Ml.new()
|> Kino.MapLibre.add_markers(markers)

