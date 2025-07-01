// --------------------------------------------------------------------------------------------------------------------
// FrmPrincipal.cs
//
// FirmaXadesNet - Demo de generación de fichero factura-e
// Copyright (C) 2014 Dpto. de Nuevas Tecnologías de la Concejalía de Urbanismo de Cartagena
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
//
// Contact info: J. Arturo Aguado
// Email: informatica@gemuc.es
// 
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Windows.Forms;

namespace DemoFacturae
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            FirmaXadesNet.XadesService xadesService = new FirmaXadesNet.XadesService();
            string ficheroFactura = Application.StartupPath + "\\Facturae3_2_2.xml";

            // Política de firma de factura-e 3.2.2
            var parametros = new FirmaXadesNet.Signature.Parameters.SignatureParameters()
            {
                SignatureMethod = FirmaXadesNet.Crypto.SignatureMethod.RSAwithSHA256,
                SigningDate = DateTime.Now,
                InputMimeType = "text/xml",
                SignaturePackaging = FirmaXadesNet.Signature.Parameters.SignaturePackaging.ENVELOPED,
                SignerRole = new FirmaXadesNet.Signature.Parameters.SignerRole(),
                SignaturePolicyInfo = new FirmaXadesNet.Signature.Parameters.SignaturePolicyInfo()
                {
                    PolicyDigestAlgorithm = FirmaXadesNet.Crypto.DigestMethod.SHA1,
                    PolicyIdentifier = "http://www.facturae.es/politica_de_firma_formato_facturae/politica_de_firma_formato_facturae_v3_1.pdf",
                    PolicyHash = "Ohixl6upD6av8N7pEvDABhEL6hM=",
                },
            };

            parametros.SignerRole.ClaimedRoles.Add("emisor");

            using (parametros.Signer = new FirmaXadesNet.Crypto.Signer(FirmaXadesNet.Utils.CertUtil.SelectCertificate()))
            {
                using (FileStream fs = new FileStream(ficheroFactura, FileMode.Open))
                {
                    var docFirmado = xadesService.Sign(fs, parametros);

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        docFirmado.Save(saveFileDialog1.FileName);
                        LogToConsole("Fichero guardado correctamente.");

                        // Validación de la firma
                        var result = xadesService.Validate(docFirmado);
                        LogToConsole(result.IsValid ? "La firma es válida" : "La firma NO es válida");
                    }
                }
            }
        }

        private void LogToConsole(string message) 
        {
            Console.Text += $"{message}\n";
        }
    }
}
