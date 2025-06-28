<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vuelos.aspx.cs" Inherits="Vuelos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Buscador de Vuelos</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Vuelos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="nav-header">
            <div class="logo">VIAJES</div>
            <nav>
                <a href="#" class="nav-link active">Vuelos</a>
                <a href="#" class="nav-link">Hoteles</a>
                <a href="#" class="nav-link">Paquetes</a>
                <a href="#" class="nav-link">Ofertas</a>
            </nav>
            <div class="user-icon">&#9787;</div>
        </header>
        <section class="search-section">
            <div class="search-box">
                <h2>Buscar Vuelos</h2>
                <div class="search-fields">
                    <input type="text" class="search-input" placeholder="Origen" />
                    <input type="text" class="search-input" placeholder="Destino" />
                    <input type="date" class="search-input" />
                    <input type="date" class="search-input" />
                    <select class="search-input">
                        <option>1 persona, Económica</option>
                        <option>2 personas, Económica</option>
                        <option>1 persona, Ejecutiva</option>
                    </select>
                    <button type="button" class="search-btn">Buscar</button>
                </div>
            </div>
        </section>
        <section class="destinos-section">
            <h2>Vuelos baratos para los mejores destinos</h2>
            <div class="destinos-grid">
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80" alt="Santiago de Chile" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Santiago de Chile</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$249.911</span>
                    </div>
                </div>
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80" alt="Mendoza" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Mendoza</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$71.726</span>
                    </div>
                </div>
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1502082553048-f009c37129b9?auto=format&fit=crop&w=400&q=80" alt="Salta" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Salta</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$83.073</span>
                    </div>
                </div>
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1465156799763-2c087c332922?auto=format&fit=crop&w=400&q=80" alt="Córdoba" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Córdoba</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$50.795</span>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>