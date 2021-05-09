from flask import Flask, request, jsonify, render_template
from flask_sqlalchemy import SQLAlchemy
from flask_marshmallow import Marshmallow
from werkzeug.utils import secure_filename
import os.path

app = Flask(__name__)
baseDir = os.path.abspath(os.path.dirname(__file__))

app.config['SQLALCHEMY_DATABASE_URI']= 'sqlite:///'+os.path.join(baseDir,'dB.sqlite')
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

dB = SQLAlchemy(app)
ma = Marshmallow(app)

class Product(dB.Model):
    id = dB.Column(dB.Integer, primary_key= True)
    name = dB.Column(dB.String(100))
    description  = dB.Column(dB.String(200))
    price = dB.Column(dB.Float)
    qty = dB.Column(dB.Integer)
    image = dB.Column(dB.Text, nullable=True)
    image_name = dB.Column(dB.Text, nullable=True)

    def __init__(self, name, description, price, qty, image, image_name):
        self.name = name
        self. description = description
        self.price = price
        self.qty = qty
        self.image = image
        self.image_name = image_name

class ProductSchema(ma.Schema):
    class Meta:
        fields = ('id', 'name', 'description','price', 'qty', 'image','image_name')

product_schema = ProductSchema()
products_schema = ProductSchema(many=True)

@app.route('/')
def home():
    return render_template('index.html')

@app.route('/product',methods=['GET','POST'])
def addProduct():
    if request.method == 'POST':
        name = request.form['name']
        description = request.form['description']
        try:
            price = float(request.form['price'])
            
        except:
            return "<h3>Provide valid integer values for price!</h3>", 400

        try:
            qty = int(request.form['quantity'])
        
        except:
            return "<h3>Provide valid integer value for quantity!</h3>", 400
        
        image = request.files['pic']
       
        image_name = secure_filename(image.filename)

        new_prod = Product(name,description,price,qty,image.read(),image_name)
        dB.session.add(new_prod)
        dB.session.commit()

        return "<h3>Product has been created!</h3>"
    
    else:
        return render_template('addProducts.html')
        
    

@app.route('/getProduct')
def getProduct():
    all_prods = Product.query.all()
        
    for row in all_prods:
        row.image = None

    result = products_schema.dump(all_prods)

    return render_template('getProducts.html',result = result, result_len = len(result), path=baseDir)

@app.route('/getProduct/<id>')
def getProductsById(id):
    single_prod = Product.query.get(id)
    if single_prod is None:
        return f"Product with id->{id} not found", 404

    return render_template('getProducts.html',result = single_prod, result_len = 1, path=baseDir, getById=True)


@app.route('/updateProduct/<id>',methods=['POST','GET'])
def updateProduct(id):
    prod = Product.query.get(id)
    if request.method == 'POST':
        name = request.form['name']
        description = request.form['description']
        try:
            price = float(request.form['price'])    
        except:
            return "<h3>Provide valid integer values for price!</h3>", 400
        try:
            qty = int(request.form['quantity'])
        except:
            return "<h3>Provide valid integer value for quantity!</h3>", 400
        image = request.files['pic']
        image_name = secure_filename(image.filename)
        
        prod.name = name
        prod.description = description
        prod.price = price
        prod.qty = qty
        prod.image = image.read()
        prod.image_name = image_name 
        dB.session.commit()

        return render_template('getProducts.html',result = prod, result_len = 1, image_name=image_name, updateFlag=True, path=baseDir, getById = True)
    
    else:        
        if prod is None:
            return f"Product with id->{id} is not found. Sorry could not update it!!"
        return render_template('updateProducts.html', id=id)

@app.route('/deleteProduct/<id>')
def deleteProduct(id):
    prod = Product.query.get(id)
    if prod is None:
        return f"Product cannot not be deleted as the id->{id} does not exist"

    dB.session.delete(prod)
    dB.session.commit()

    return  render_template('getProducts.html',result = prod, result_len = 1, deleteFlag = True, path=baseDir, getById = True)
if __name__=='__main__':
    app.run(debug=True)